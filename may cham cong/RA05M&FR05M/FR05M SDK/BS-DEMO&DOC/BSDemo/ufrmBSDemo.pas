unit ufrmBSDemo;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.ComCtrls, Vcl.ToolWin, Vcl.StdCtrls,
  Vcl.ExtCtrls, Vcl.Buttons, IdHTTPWebBrokerBridge, Web.HTTPApp, Vcl.AppEvnts;

type
  TForm1 = class(TForm)
    GroupBox1: TGroupBox;
    mmoResultBody: TMemo;
    mmoResultHeader: TMemo;
    PageControl1: TPageControl;
    TabSheet1: TTabSheet;
    TabSheet2: TTabSheet;
    mmoReceiveCmd: TMemo;
    GroupBox2: TGroupBox;
    lbCommandBinary: TListBox;
    mmoCommandtHeader: TMemo;
    ToolBar2: TToolBar;
    ToolButton15: TToolButton;
    ToolButton16: TToolButton;
    ToolButton17: TToolButton;
    ToolBar1: TToolBar;
    btnCmd01: TToolButton;
    btnCmd02: TToolButton;
    btnCmd03: TToolButton;
    btnCmd04: TToolButton;
    btnCmd05: TToolButton;
    btnCmd06: TToolButton;
    btnCmd07: TToolButton;
    btnCmd08: TToolButton;
    btnCmd09: TToolButton;
    btnCmd10: TToolButton;
    btnCmd11: TToolButton;
    btnCmd12: TToolButton;
    btnCmd13: TToolButton;
    btnCmd14: TToolButton;
    btnCmd15: TToolButton;
    btnCmd16: TToolButton;
    btnCmd17: TToolButton;
    btnCmd18: TToolButton;
    btnCmd19: TToolButton;
    ToolBar3: TToolBar;
    ToolButton1: TToolButton;
    Panel2: TPanel;
    SpeedButton1: TSpeedButton;
    ApplicationEvents1: TApplicationEvents;
    PageControl2: TPageControl;
    TabSheet4: TTabSheet;
    TabSheet5: TTabSheet;
    mmoCommandBody: TMemo;
    mmoCommandBodySample: TMemo;
    Panel1: TPanel;
    lblPort: TLabel;
    btnServer: TButton;
    EditPort: TEdit;
    OpenDialog1: TOpenDialog;
    ToolButton2: TToolButton;
    Label1: TLabel;
    realtime_enroll_data: TGroupBox;
    mmoEnrollData: TMemo;
    realtime_glog: TGroupBox;
    mmoGLog: TMemo;
    procedure ToolButton1Click(Sender: TObject);
    procedure btnCmd01Click(Sender: TObject);
    procedure btnServerClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure ApplicationEvents1Idle(Sender: TObject; var Done: Boolean);
    procedure SpeedButton1Click(Sender: TObject);
    procedure ToolButton15Click(Sender: TObject);
    procedure ToolButton16Click(Sender: TObject);
    procedure ToolButton17Click(Sender: TObject);
    procedure ToolButton2Click(Sender: TObject);
    procedure FormCloseQuery(Sender: TObject; var CanClose: Boolean);
  private
    FServer: TIdHTTPWebBrokerBridge;
    FSendStream: TMemoryStream;
    FTransList: TList;
    FCmdCode: Integer;
    FNeedSend: Boolean;
    { Private declarations }
  public
    function GetSendData(var TransId: Integer; var CmdCode: string; var Stream: TStream): Boolean;
    function GetResultCmdType(const TransId: Integer): Integer;
    { Public declarations }
  end;

var
  Form1: TForm1;
  CurrentPath: string;

implementation

{$R *.dfm}

const
  CMD_CODE_STRS: array[1..19] of string =(
    'GET_ENROLL_DATA'      ,    //1
    'SET_ENROLL_DATA'      ,    //2
    'SET_TIME'             ,    //3
    'RESET_FK'             ,    //4
    'DELETE_USER'          ,    //5
    'SET_USER_NAME'        ,    //6
    'SET_USER_PRIVILEGE'   ,    //7
    'ENABLE_ENROLL_FUNC'   ,    //8
    'GET_USER_ID_LIST'     ,    //9
    'GET_LOG_DATA'         ,    //10
    'ENABLE_USER'          ,    //11
    'SET_FK_NAME'          ,    //12
    'CLEAR_LOG_DATA'       ,    //13
    'CLEAR_ENROLL_DATA'    ,    //14
    'GET_DEVICE_STATUS'    ,    //15
    'SET_USER_INFO'        ,    //16
    'GET_USER_INFO'        ,    //17
    'SET_WEB_SERVER_INFO'  ,    //18
    'UPDATE_FIRMWARE'      );   //19


procedure TForm1.ApplicationEvents1Idle(Sender: TObject; var Done: Boolean);
begin
  if FServer.Active then btnServer.Caption := 'Stop' else btnServer.Caption := 'Start';
  EditPort.Enabled := not FServer.Active;
end;

procedure TForm1.btnCmd01Click(Sender: TObject);
var
  json: string;
  sl: TStrings;
begin
  if FNeedSend then
  begin
    Application.MessageBox('The command has not been processed, please wait', 'title');
    Exit;
  end;
  FCmdCode := TToolButton(Sender).Index + 1;
  sl := mmoCommandBodySample.Lines;
  sl.BeginUpdate;
  sl.Clear;
  case FCmdCode of
    1:
    begin
      json := '{"user_id":"8","backup_number":10}';
      sl.Add(json);
      sl.Add('user_id:string, enroll id to be obtained');
      sl.Add('backup_number:integer, Registration data backup number to obtain');
    end;
    2: ;
    3:
    begin
      json := Format('{"time":"%s"}', [FormatDateTime('YYYYMMDDhhmmss', Now())]);
      sl.Add(json);
      sl.Add('time: string,Set the time format of the device to YYYYMMDDhhmmss');
    end;
    4:
    begin
      json := '';
      sl.Add('No parameter');
    end;
    5:
    begin
      json := '{"user_id": "1"}';
      sl.Add(json);
      sl.Add('user_id: string, Registration number to be deleted');
    end;
    6:
    begin
      json := '{"user_id": "1", "user_name": "test"}';
      sl.Add(json);
      sl.Add('user_id: string,Registration number to be modified');
      sl.Add('user_name: string,Name of the registration number to be modified');
    end;
    7:
    begin
      json := '{"user_id": "1", "user_privilege": "USER"}';
      sl.Add(json);
      sl.Add('user_id: string,Registration number to be modified');
      sl.Add('user_privilege: string,There are three values for the authority of the registration number to be modified:USER,MANAGER,BACKUP');
    end;
    8:
    begin
      json := '{"enable_flag":"ON"}';
      sl.Add(json);
      sl.Add('enable_flag: string,To turn on or off the user registration function of the machine, there are two values:ON,OFF');
    end;
    9:
    begin
      json := '';
      sl.Add('No parameter');
    end;
    10:
    begin
      json := Format('{"begin_time":"%s","end_time":"%s"}', [FormatDateTime('YYYYMMDDhhmmss', Now() - 31),  FormatDateTime('YYYYMMDDhhmmss', Now())]);
      sl.Add(json);
      sl.Add('begin_time: string, Time format is YYYYMMDDhhmmss, When the field is empty or does not exist, all attendance record data recorded before end_time will be obtained');
      sl.Add('end_time: string, time format is YYYYMMDDhhmmss,When the field is empty or does not exist,All attendance record data recorded after begin_time will be obtained');
      sl.Add('If the two fields are invalid values, all attendance record data in the machine will be obtained.');
    end;
    11:
    begin
      json := '{"user_id": "1", "enable_flag": "ON"}';
      sl.Add(json);
      sl.Add('user_id: string,Registration number to be modified');
      sl.Add('user_name: string,There are two kinds of enabling values for the registration number to be modified:ON,OFF');
    end;
    12:
    begin
      json := '{"fk_name": "FK New Name"}';
      sl.Add(json);
      sl.Add('fk_name: string,To set a new name for the machine');
    end;
    13:
    begin
      json := '';
      sl.Add('No parameter');
    end;
    14:
    begin
      json := '';
      sl.Add('No parameter');
    end;
    15:
    begin
      json := '';
      sl.Add('No parameter');
    end;
    16:
    begin
      json := '{"user_id": "1", "user_name": "test", "user_privilege": "USER","enroll_data_array":[{"backup_number":1,"enroll_data":"BIN_1"}],"user_photo":"BIN_x"}';
      sl.Add(json);
      sl.Add('user_id: string,Registration number to upload');
      sl.Add('user_name: string,The name of the registration number to upload');
      sl.Add('user_privilege: string,There are three values for the authority of the enroll number to be uploaded：USER,MANAGER,BACKUP');
      sl.Add('enroll_data_array: array, enroll data to upload');
      sl.Add('enroll_data_array->backup_number: integer,enroll data backup number to upload');
      sl.Add('enroll_data_array->enroll_data: string,The enroll data to be uploaded is binary data in "bin_ X", x is counted from 1');
      sl.Add('user_photo: string,The enroll data to be uploaded is binary data in "BIN_x"');
      sl.Add('Note: the data is "BIN_x". Indicates that the data is binary data, followed by a section of binary data after the structure, X is binary serial number, counting from 1');
      sl.Add('Binary data format 4BYTE（DataLen）DataLen BYTE data，Multiple binary data, which is composed of multiple native structures');
    end;
    17:
    begin
      json := '{"user_id": "1"}';
      sl.Add(json);
      sl.Add('user_id: string,enroll number to download');
      sl.Add('The received data structure is similar to the upload registration data') ;
      sl.Add('user_name: string,The name of the downloaded registration number');
      sl.Add('user_privilege: string,Permission of the download the registration number ');
      sl.Add('enroll_data_array: array,Registration data downloaded');
      sl.Add('enroll_data_array->backup_number: integer,Downloaded registration data backup number');
      sl.Add('enroll_data_array->enroll_data: string,The downloaded registration data binary data is indicated by "BIN_x", where x is counted from 1');
      sl.Add('user_photo: string,The downloaded enroll data binary data is indicated by "BIN_x"');
      sl.Add('Note: the data is "BIN_x". Indicates that the data is binary data, followed by a section of binary data, x is the binary serial number, counting from 1');
      sl.Add('Binary data format ,4BYTE（DataLen）DataLen BYTE data，Multiple binary data is composed of multiple local structures');
    end;
    18:
    begin
      json := '{"ip_address": "192.168.1.100", "port": "8000"}';
      sl.Add(json);
      sl.Add('ip_address: string,Server IP address');
      sl.Add('port: string,The server service port number');
    end;
    19:
    begin
      json := '{"firmware_file_name":"alv4311ffi50b_um","firmware_bin_data":"BIN_1"}';
      sl.Add(json);
      sl.Add('firmware_file_name: string,Firmware name to upgrade,it Can be viewed in receive_CMD received');
      sl.Add('firmware_bin_data: string,firmware is BIN_1，Because there is only one binary firmware binary to upgrade');
    end;
  end;
  sl.EndUpdate;
  mmoCommandBody.Text := json;
  lbCommandBinary.Clear;
end;

procedure TForm1.btnServerClick(Sender: TObject);
begin
  if FServer.Active then FServer.Active := False
  else begin
    FServer.Bindings.Clear;
    FServer.DefaultPort := StrToInt(EditPort.Text);
    FServer.Active := True;
  end;
end;

procedure TForm1.FormCloseQuery(Sender: TObject; var CanClose: Boolean);
begin
  FServer.Active := False;
  if not FServer.Active then
    CanClose := True;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  CurrentPath := ExtractFilePath(ParamStr(0));
  FSendStream := TMemoryStream.Create;
  FTransList := TList.Create;
  FServer := TIdHTTPWebBrokerBridge.Create(Self);
  ForceDirectories(CurrentPath + 'data');
end;

function TForm1.GetResultCmdType(const TransId: Integer): Integer;
begin
  Result := Integer(FTransList[TransId - 1]);
end;

function TForm1.GetSendData(var TransId: Integer; var CmdCode: string; var Stream: TStream): Boolean;
begin
  if FNeedSend then FNeedSend := False
  else Exit(False);

  //只是为了显示有开发者看命令头里的信息
  mmoCommandtHeader.Clear;
  mmoCommandtHeader.Lines.Add(Format('%s: %s', ['Content-Type', 'application/octet-stream']));
  mmoCommandtHeader.Lines.Add(Format('%s: %s', ['response_code', 'OK']));
  mmoCommandtHeader.Lines.Add(Format('%s: %d', ['trans_id', TransId]));
  mmoCommandtHeader.Lines.Add(Format('%s: %s', ['cmd_code', cmdcode]));
  mmoCommandtHeader.Lines.Add(Format('%s: %d', ['blk_len',FSendStream.Size]));
  mmoCommandtHeader.Lines.Add(Format('%s: %d', ['blk_no', 0]));

  TransId := FTransList.Add(Pointer(FCmdCode)) + 1;
  CmdCode := CMD_CODE_STRS[FCmdCode];
  stream := TMemoryStream.Create;
  Stream.CopyFrom(FSendStream, 0);
  Result := True;
end;

procedure TForm1.SpeedButton1Click(Sender: TObject);
var
  s: AnsiString;
  i: Integer;
  fs: TFileStream;
  len: Integer;
begin
  if FNeedSend then
  begin
    Application.MessageBox('The command has not been processed, please wait', 'title');
    Exit;
  end;
  FSendStream.Size := 0;
  //s := AnsiString(mmoCommandBody.Text);
  //使用UTF8编码方式发送字符串
  s := AnsiString(PAnsiChar(TEncoding.UTF8.GetBytes(mmoCommandBody.Text)));
  len := Length(s) + 1;
  FSendStream.Write(len, SizeOf(Integer));
  FSendStream.Write(PAnsiChar(s)^, len);
  for i := 0 to lbCommandBinary.Count - 1 do
  begin
    fs := TFileStream.Create(lbCommandBinary.Items[i], fmOpenRead or fmShareDenyNone);
    len := fs.Size;
    FSendStream.Write(len, SizeOf(Integer));
    FSendStream.CopyFrom(fs, 0);
    fs.Free;
  end;

  FNeedSend := True;
end;

procedure TForm1.ToolButton15Click(Sender: TObject);
begin
  if OpenDialog1.Execute() then
    lbCommandBinary.Items.Add(OpenDialog1.FileName);
end;

procedure TForm1.ToolButton16Click(Sender: TObject);
begin
  if (lbCommandBinary.ItemIndex >= 0) and OpenDialog1.Execute() then
    lbCommandBinary.Items[lbCommandBinary.ItemIndex] := OpenDialog1.FileName;

end;

procedure TForm1.ToolButton17Click(Sender: TObject);
begin
  lbCommandBinary.DeleteSelected;
end;

procedure TForm1.ToolButton1Click(Sender: TObject);
begin
  mmoReceiveCmd.Clear;
end;

procedure TForm1.ToolButton2Click(Sender: TObject);
begin
  lbCommandBinary.Clear;
end;

end.
