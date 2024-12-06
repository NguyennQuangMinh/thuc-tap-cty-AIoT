unit WebModuleUnit1;

interface

uses
  System.SysUtils, System.Classes, Web.HTTPApp, superobject;

type
  TWebModule1 = class(TWebModule)
    procedure WebModule1DefaultHandlerAction(Sender: TObject;
      Request: TWebRequest; Response: TWebResponse; var Handled: Boolean);
    procedure WebModuleCreate(Sender: TObject);
  private
    FCmdResultStream: TStream;
    procedure HandledReceiveCmd(Request: TWebRequest; Response: TWebResponse);
    procedure HandledCmdResult(Request: TWebRequest; Response: TWebResponse);
    procedure HandledRealtimeGLog(Request: TWebRequest; Response: TWebResponse);
    procedure HandledRealtimeEnrollData(Request: TWebRequest; Response: TWebResponse);
    function ReadData(Request: TWebRequest; AStream: TStream; const isLast: Boolean;
      GetSaveFileName: TFunc<ISuperObject, Integer, string>): string;
    { Private declarations }
  public
    { Public declarations }
  end;

var
  WebModuleClass: TComponentClass = TWebModule1;

implementation

uses
  ufrmBSDemo, IdHTTPWebBrokerBridge;

{%CLASSGROUP 'Vcl.Controls.TControl'}

{$R *.dfm}

type
  TMyHTTPAppRequest = class(TIdHTTPAppRequest)

  end;

procedure TWebModule1.HandledCmdResult(Request: TWebRequest;
  Response: TWebResponse);
var
  cmdType: Integer;
  s: string;
  isLast: Boolean;
begin
  cmdType := Form1.GetResultCmdType(StrToInt(Request.GetFieldByName('trans_id')));
  isLast := Request.GetFieldByName('blk_no') = '0';
  s := ReadData(Request, FCmdResultStream, isLast,
    function(json: ISuperObject; Index: Integer): string
    begin
      Result := Format('%sdata\cmd_%.2d_Bin_%d.dat', [CurrentPath, cmdType, Index])
    end);
  if isLast then
  begin
    Form1.mmoResultBody.Text := s;
  end;

  try
    case cmdType of
      17:
      begin

      end;
    end;
  finally

  end;
  Response.CustomHeaders.Values['response_code'] := 'OK';
  Response.StatusCode := 200;
  Response.SendResponse;
end;

procedure TWebModule1.HandledRealtimeEnrollData(Request: TWebRequest;
  Response: TWebResponse);
var
  s: string;
  isLast: Boolean;
begin
  isLast := Request.GetFieldByName('blk_no') = '0';
  s := ReadData(Request, FCmdResultStream, isLast,
    function(json: ISuperObject; Index: Integer): string
    begin
      Result := Format('%sdata\enroll_%s_Bin_%d.dat', [CurrentPath, json.S['user_id'], Index])
    end);
  if isLast then
  begin
    Form1.mmoEnrollData.Lines.Add(s);
  end;

  Response.CustomHeaders.Values['response_code'] := 'OK';
  Response.CustomHeaders.Values['trans_id'] :=Request.GetFieldByName('trans_id');
  Response.StatusCode := 200;
  //本句不需要加的，是为了Indy的BUG，没有数据时，Indy会强行回复一个字符串，并修改ContentType
  Response.Content := '1';
  Response.SendResponse;
end;

procedure TWebModule1.HandledRealtimeGLog(Request: TWebRequest;
  Response: TWebResponse);
var
  s: string;
  isLast: Boolean;
begin
  isLast := Request.GetFieldByName('blk_no') = '0';
  s := ReadData(Request, FCmdResultStream, isLast,
    function(json: ISuperObject; Index: Integer): string
    begin
      Result := Format('%sdata\LogPhoto_%s_%s.dat', [CurrentPath, json.S['user_id'], json.S['io_time'], Index])
    end);
  if isLast then
  begin
    Form1.mmoGLog.Lines.Add(s);
  end;

  Response.CustomHeaders.Values['response_code'] := 'OK';
  Response.CustomHeaders.Values['trans_id'] :=Request.GetFieldByName('trans_id');
  Response.StatusCode := 200;
  //本句不需要加的，是为了Indy的BUG，没有数据时，Indy会强行回复一个字符串，并修改ContentType
  Response.Content := '1';
  Response.SendResponse;
end;

procedure TWebModule1.HandledReceiveCmd(Request: TWebRequest;
  Response: TWebResponse);
var
  trans_id: Integer;
  cmdcode: string;
  Stream: TStream;
begin
  Response.StatusCode := 200;
//  headers.Values['dev_id'] := Request.GetFieldByName('dev_id');


  if Form1.GetSendData(trans_id, cmdcode, Stream) then
  begin
    Response.ContentStream := Stream;
    Response.CustomHeaders.Values['response_code'] := 'OK';
    Response.CustomHeaders.Values['trans_id'] := IntToStr(trans_id);
    Response.CustomHeaders.Values['cmd_code'] := cmdcode;
    Response.CustomHeaders.Values['blk_len'] := IntToStr(Stream.Size);
    Response.CustomHeaders.Values['blk_no'] := '0';
  end
  else begin
    Response.CustomHeaders.Values['trans_id'] := Request.GetFieldByName('trans_id');
    Response.CustomHeaders.Values['response_code'] := 'ERROR';
  end;

  Response.SendResponse;
end;


function TWebModule1.ReadData(Request: TWebRequest; AStream: TStream;
  const isLast: Boolean; GetSaveFileName: TFunc<ISuperObject, Integer, string>): string;
var
  len, dataLen: Integer;
  s: AnsiString;
  ws: string;
  json: ISuperObject;
  n: Integer;
  ms: TMemoryStream;
begin
  Result := '';
  len := Request.ContentLength;
  if len > 0 then
  begin
    ms := TMemoryStream.Create;
    ms.Size := len;
    Request.ReadClient(ms.Memory^, dataLen);
    AStream.CopyFrom(ms, 0);
  end
  else ms := nil;
  if Request.GetFieldByName('blk_no') = '0' then
  begin
    if ms = nil then
      ms := TMemoryStream.Create;
//    Form1.lbResultBinary.Clear;
//    Form1.mmoResultBody.Clear;
    AStream.Position := 0;
    AStream.Read(dataLen, SizeOf(dataLen));
    SetLength(s, dataLen);
    AStream.Read(s[1], dataLen);
    ws := TEncoding.UTF8.GetString(BytesOf(s));
    json := SO(ws);
    Result := json.AsJSon(True, False);
    n := 0;
    while AStream.Read(dataLen, SizeOf(dataLen)) = SizeOf(dataLen) do
    begin
      Inc(n);
      ms.Size := 0;
      ms.CopyFrom(AStream, dataLen);
      if Assigned(GetSaveFileName) then
      ms.SaveToFile(GetSaveFileName(json, n));
    end;
    AStream.Size := 0;
  end;
  ms.Free;

end;

procedure TWebModule1.WebModule1DefaultHandlerAction(Sender: TObject;
  Request: TWebRequest; Response: TWebResponse; var Handled: Boolean);
var
  request_code: string;
begin
  Response.ContentType := Request.ContentType;
  Response.ContentLength := 0;
  request_code := Request.GetFieldByName('request_code');
  if request_code = 'receive_cmd' then
  begin
    Form1.mmoReceiveCmd.Lines.Add(TMyHTTPAppRequest(Request).FRequestInfo.RawHeaders.Text);
    HandledReceiveCmd(Request, Response);
  end
  else if request_code = 'send_cmd_result' then
  begin
    Form1.mmoResultHeader.Clear;
    Form1.mmoResultHeader.Lines.Add(TMyHTTPAppRequest(Request).FRequestInfo.RawHeaders.Text);
    HandledCmdResult(Request, Response);
  end
  else if request_code = 'realtime_glog' then
  begin
    Form1.mmoGLog.Lines.Add(TMyHTTPAppRequest(Request).FRequestInfo.RawHeaders.Text);
    HandledRealtimeGLog(Request, Response);
  end
  else if request_code = 'realtime_enroll_data' then
  begin
    Form1.mmoEnrollData.Lines.Add(TMyHTTPAppRequest(Request).FRequestInfo.RawHeaders.Text);
    HandledRealtimeEnrollData(Request, Response);
  end;
end;

procedure TWebModule1.WebModuleCreate(Sender: TObject);
begin
  FCmdResultStream := TMemoryStream.Create;
end;

end.
