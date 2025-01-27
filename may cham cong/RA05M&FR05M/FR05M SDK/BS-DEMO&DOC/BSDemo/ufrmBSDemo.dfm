object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'BS Demo'
  ClientHeight = 780
  ClientWidth = 962
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCloseQuery = FormCloseQuery
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object PageControl1: TPageControl
    Left = 0
    Top = 41
    Width = 962
    Height = 739
    ActivePage = TabSheet2
    Align = alClient
    TabOrder = 0
    object TabSheet1: TTabSheet
      Caption = 'Task command'
      object Panel2: TPanel
        Left = 0
        Top = 566
        Width = 954
        Height = 145
        Align = alBottom
        BevelOuter = bvNone
        Caption = 'Panel2'
        TabOrder = 0
        object ToolBar3: TToolBar
          Left = 0
          Top = 0
          Width = 954
          Height = 23
          AutoSize = True
          ButtonHeight = 21
          ButtonWidth = 31
          Caption = 'ToolBar2'
          Flat = False
          ShowCaptions = True
          TabOrder = 0
          object ToolButton1: TToolButton
            Left = 0
            Top = 0
            Caption = #28165#31354
            ImageIndex = 0
            OnClick = ToolButton1Click
          end
        end
        object mmoReceiveCmd: TMemo
          Left = 0
          Top = 23
          Width = 954
          Height = 122
          Align = alClient
          ReadOnly = True
          ScrollBars = ssBoth
          TabOrder = 1
        end
      end
      object TPanel
        Left = 0
        Top = 0
        Width = 954
        Height = 566
        Align = alClient
        BevelOuter = bvNone
        ShowCaption = False
        TabOrder = 1
        object GroupBox1: TGroupBox
          Left = 0
          Top = 309
          Width = 954
          Height = 257
          Align = alBottom
          Caption = 'Command result'
          TabOrder = 0
          object TPanel
            Left = 187
            Top = 15
            Width = 765
            Height = 240
            Align = alClient
            BevelOuter = bvNone
            TabOrder = 0
            object TLabel
              Left = 0
              Top = 0
              Width = 765
              Height = 13
              Align = alTop
              Alignment = taCenter
              Caption = 'Result body'
              ExplicitWidth = 57
            end
            object mmoResultBody: TMemo
              Left = 0
              Top = 13
              Width = 765
              Height = 227
              Align = alClient
              ScrollBars = ssBoth
              TabOrder = 0
            end
          end
          object TPanel
            Left = 2
            Top = 15
            Width = 185
            Height = 240
            Align = alLeft
            BevelOuter = bvNone
            TabOrder = 1
            object TLabel
              Left = 0
              Top = 0
              Width = 185
              Height = 13
              Align = alTop
              Alignment = taCenter
              Caption = 'Result head'
              ExplicitWidth = 57
            end
            object mmoResultHeader: TMemo
              Left = 0
              Top = 13
              Width = 185
              Height = 227
              Align = alClient
              ScrollBars = ssBoth
              TabOrder = 0
            end
          end
        end
        object GroupBox2: TGroupBox
          Left = 0
          Top = 65
          Width = 954
          Height = 244
          Align = alClient
          Caption = 'Command'
          TabOrder = 1
          object TPanel
            Left = 767
            Top = 15
            Width = 185
            Height = 227
            Align = alRight
            BevelOuter = bvNone
            TabOrder = 0
            object TLabel
              Left = 0
              Top = 0
              Width = 185
              Height = 13
              Align = alTop
              Alignment = taCenter
              Caption = 'Command binary data'
              ExplicitWidth = 105
            end
            object SpeedButton1: TSpeedButton
              Left = 0
              Top = 205
              Width = 185
              Height = 22
              Align = alBottom
              Caption = 'Submit command'
              OnClick = SpeedButton1Click
              ExplicitLeft = 2
              ExplicitTop = 152
            end
            object Label1: TLabel
              Left = 0
              Top = 13
              Width = 185
              Height = 26
              Align = alTop
              Caption = 'Note: when the command contains'#13#10' binary data,'
              ExplicitWidth = 166
            end
            object lbCommandBinary: TListBox
              Left = 0
              Top = 39
              Width = 185
              Height = 143
              Align = alClient
              ItemHeight = 13
              TabOrder = 0
            end
            object ToolBar2: TToolBar
              Left = 0
              Top = 182
              Width = 185
              Height = 23
              Align = alBottom
              AutoSize = True
              ButtonHeight = 21
              ButtonWidth = 39
              Caption = 'ToolBar2'
              Flat = False
              ShowCaptions = True
              TabOrder = 1
              object ToolButton15: TToolButton
                Left = 0
                Top = 0
                Caption = 'Add'
                ImageIndex = 0
                OnClick = ToolButton15Click
              end
              object ToolButton16: TToolButton
                Left = 39
                Top = 0
                Caption = 'Modify'
                ImageIndex = 1
                OnClick = ToolButton16Click
              end
              object ToolButton17: TToolButton
                Left = 78
                Top = 0
                Caption = 'Delete'
                ImageIndex = 2
                OnClick = ToolButton17Click
              end
              object ToolButton2: TToolButton
                Left = 117
                Top = 0
                Caption = 'Clear'
                ImageIndex = 3
                OnClick = ToolButton2Click
              end
            end
          end
          object TPanel
            Left = 187
            Top = 15
            Width = 580
            Height = 227
            Align = alClient
            BevelOuter = bvNone
            TabOrder = 1
            object TLabel
              Left = 0
              Top = 0
              Width = 580
              Height = 13
              Align = alTop
              Alignment = taCenter
              Caption = 'Command body'
              ExplicitWidth = 74
            end
            object PageControl2: TPageControl
              Left = 0
              Top = 13
              Width = 580
              Height = 214
              ActivePage = TabSheet5
              Align = alClient
              TabOrder = 0
              object TabSheet4: TTabSheet
                Caption = 'Data'
                object mmoCommandBody: TMemo
                  Left = 0
                  Top = 0
                  Width = 572
                  Height = 186
                  Align = alClient
                  ScrollBars = ssBoth
                  TabOrder = 0
                end
              end
              object TabSheet5: TTabSheet
                Caption = 'Specify'
                ImageIndex = 1
                object mmoCommandBodySample: TMemo
                  Left = 0
                  Top = 0
                  Width = 572
                  Height = 186
                  Align = alClient
                  ReadOnly = True
                  ScrollBars = ssBoth
                  TabOrder = 0
                end
              end
            end
          end
          object TPanel
            Left = 2
            Top = 15
            Width = 185
            Height = 227
            Align = alLeft
            BevelOuter = bvNone
            TabOrder = 2
            object TLabel
              Left = 0
              Top = 0
              Width = 185
              Height = 13
              Align = alTop
              Alignment = taCenter
              Caption = 'Command header'
              ExplicitWidth = 84
            end
            object mmoCommandtHeader: TMemo
              Left = 0
              Top = 13
              Width = 185
              Height = 214
              Align = alClient
              ScrollBars = ssBoth
              TabOrder = 0
            end
          end
        end
        object ToolBar1: TToolBar
          Left = 0
          Top = 0
          Width = 954
          Height = 65
          AutoSize = True
          ButtonHeight = 21
          ButtonWidth = 128
          Caption = 'ToolBar1'
          Flat = False
          ShowCaptions = True
          TabOrder = 2
          object btnCmd01: TToolButton
            Left = 0
            Top = 0
            AllowAllUp = True
            Caption = 'GET_ENROLL_DATA'
            Grouped = True
            ImageIndex = 0
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd02: TToolButton
            Left = 128
            Top = 0
            AllowAllUp = True
            Caption = 'SET_ENROLL_DATA'
            Grouped = True
            ImageIndex = 1
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd03: TToolButton
            Left = 256
            Top = 0
            AllowAllUp = True
            Caption = 'SET_TIME'
            Grouped = True
            ImageIndex = 2
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd04: TToolButton
            Left = 384
            Top = 0
            AllowAllUp = True
            Caption = 'RESET_FK'
            Grouped = True
            ImageIndex = 3
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd05: TToolButton
            Left = 512
            Top = 0
            AllowAllUp = True
            Caption = 'DELETE_USER'
            Grouped = True
            ImageIndex = 4
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd06: TToolButton
            Left = 640
            Top = 0
            AllowAllUp = True
            Caption = 'SET_USER_NAME'
            Grouped = True
            ImageIndex = 5
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd07: TToolButton
            Left = 768
            Top = 0
            AllowAllUp = True
            AutoSize = True
            Caption = 'SET_USER_PRIVILEGE'
            Grouped = True
            ImageIndex = 6
            Wrap = True
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd08: TToolButton
            Left = 0
            Top = 21
            AllowAllUp = True
            Caption = 'ENABLE_ENROLL_FUNC'
            Grouped = True
            ImageIndex = 7
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd09: TToolButton
            Left = 128
            Top = 21
            AllowAllUp = True
            Caption = 'GET_USER_ID_LIST'
            Grouped = True
            ImageIndex = 8
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd10: TToolButton
            Left = 256
            Top = 21
            AllowAllUp = True
            Caption = 'GET_LOG_DATA'
            Grouped = True
            ImageIndex = 9
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd11: TToolButton
            Left = 384
            Top = 21
            AllowAllUp = True
            Caption = 'ENABLE_USER'
            Grouped = True
            ImageIndex = 10
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd12: TToolButton
            Left = 512
            Top = 21
            AllowAllUp = True
            Caption = 'SET_FK_NAME'
            Grouped = True
            ImageIndex = 11
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd13: TToolButton
            Left = 640
            Top = 21
            AllowAllUp = True
            Caption = 'CLEAR_LOG_DATA'
            Grouped = True
            ImageIndex = 12
            Wrap = True
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd14: TToolButton
            Left = 0
            Top = 42
            AllowAllUp = True
            Caption = 'CLEAR_ENROLL_DATA'
            Grouped = True
            ImageIndex = 13
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd15: TToolButton
            Left = 128
            Top = 42
            AllowAllUp = True
            Caption = 'GET_DEVICE_STATUS'
            Grouped = True
            ImageIndex = 14
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd16: TToolButton
            Left = 256
            Top = 42
            AllowAllUp = True
            Caption = 'SET_USER_INFO'
            Grouped = True
            ImageIndex = 15
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd17: TToolButton
            Left = 384
            Top = 42
            AllowAllUp = True
            Caption = 'GET_USER_INFO'
            Grouped = True
            ImageIndex = 16
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd18: TToolButton
            Left = 512
            Top = 42
            AllowAllUp = True
            Caption = 'SET_WEB_SERVER_INFO'
            Grouped = True
            ImageIndex = 17
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
          object btnCmd19: TToolButton
            Left = 640
            Top = 42
            AllowAllUp = True
            Caption = 'UPDATE_FIRMWARE'
            Grouped = True
            ImageIndex = 18
            Style = tbsCheck
            OnClick = btnCmd01Click
          end
        end
      end
    end
    object TabSheet2: TTabSheet
      Caption = 'Realtime data'
      ImageIndex = 1
      object realtime_enroll_data: TGroupBox
        Left = 0
        Top = 0
        Width = 480
        Height = 711
        Align = alClient
        Caption = 'realtime_enroll_data'
        TabOrder = 0
        object mmoEnrollData: TMemo
          Left = 2
          Top = 15
          Width = 476
          Height = 694
          Align = alClient
          ReadOnly = True
          ScrollBars = ssBoth
          TabOrder = 0
        end
      end
      object realtime_glog: TGroupBox
        Left = 480
        Top = 0
        Width = 474
        Height = 711
        Align = alRight
        Caption = 'realtime_glog'
        TabOrder = 1
        object mmoGLog: TMemo
          Left = 2
          Top = 15
          Width = 470
          Height = 694
          Align = alClient
          ReadOnly = True
          ScrollBars = ssBoth
          TabOrder = 0
        end
      end
    end
  end
  object Panel1: TPanel
    Left = 0
    Top = 0
    Width = 962
    Height = 41
    Align = alTop
    BevelOuter = bvNone
    Caption = 'Panel1'
    ShowCaption = False
    TabOrder = 1
    object lblPort: TLabel
      Left = 15
      Top = 14
      Width = 71
      Height = 13
      Caption = 'Port number'#65306
    end
    object btnServer: TButton
      Left = 219
      Top = 10
      Width = 75
      Height = 25
      Caption = 'Start'
      TabOrder = 0
      OnClick = btnServerClick
    end
    object EditPort: TEdit
      Left = 92
      Top = 11
      Width = 121
      Height = 21
      TabOrder = 1
      Text = '802'
    end
  end
  object ApplicationEvents1: TApplicationEvents
    OnIdle = ApplicationEvents1Idle
    Left = 864
    Top = 8
  end
  object OpenDialog1: TOpenDialog
    Filter = '*.dat|*.dat'
    FilterIndex = 0
    Left = 355
    Top = 209
  end
end
