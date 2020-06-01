; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!
; ##############################################
; MapWindow5 Inno Setup Script
; ##############################################

#define ExeBinPath "..\bin\x86\Release"
#define SamplePath "testdata"
#define CPU "Win32"
#define vcredist "vcredist_x86-2017.exe"
#define SystemFlag "32bit"
#define MyAppName "MapWindow5"
#define MyAppPublisher "MapWindow Open Source GIS Community"
#define MyAppURL "https://www.mapwindow.org/documentation/mapwindow5/"
#define ReleaseNotes ExeBinPath + "\..\..\..\src\SolutionItems\ReleaseNotes.rtf"
#define GdalLicensePath ExeBinPath + "\..\..\..\..\..\MapWinGIS\git\support\GDAL_SDK\licenses\

;;#define x64BitVersion true

#ifdef x64BitVersion
  #define CPU "x64"
  #define vcredist "vcredist_x64-2017.exe"
  #define ExeBinPath "..\bin\x64\Release"
  #define SystemFlag "64bit"
#endif
#define MyAppVersion GetFileVersion(ExeBinPath + '\MapWindow.exe')

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
#ifdef x64BitVersion
  ;; x64:
  AppId={{AF7BDDC6-2263-47B0-9AA2-DA03CA6E8DC6}
#else
  ;; x86:
  AppId={{EB12FA54-F2EE-4536-9A3E-3477A6049798}
#endif

AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\MapWindow5
DisableProgramGroupPage=no
DefaultGroupName={#MyAppName}
LicenseFile={#ExeBinPath}\..\..\..\licenses\MapWindow5License.rtf
OutputDir=Output
OutputBaseFilename=MapWindow-v{#MyAppVersion}-{#CPU}
SetupIconFile=..\src\MW5\MW5.ico
UninstallDisplayIcon={uninstallexe}
Compression=lzma
SolidCompression=yes
WizardImageFile=WizImage-MW.bmp
WizardSmallImageFile=WizSmallImage-MW.bmp
AppCopyright={#MyAppPublisher}
PrivilegesRequired=none
MinVersion=0,6.0
ChangesEnvironment=no
AlwaysShowDirOnReadyPage=True
AlwaysShowGroupOnReadyPage=true
EnableDirDoesntExistWarning=True
;; UninstallDisplayName=MapWindow5 GIS uninstall
CompressionThreads=2
LZMANumBlockThreads=2
AppComments=This package will install {#MyAppName} {#MyAppVersion}
AppContact=Paul Meems (info@mapwindow.nl)
VersionInfoCompany=MapWindow Open Source GIS Team [www.mapwindow.org]
VersionInfoCopyright=Mozilla Public License (MPL) 1.1
VersionInfoDescription=MapWindow Open Source GIS [www.mapwindow.org]
VersionInfoProductName={#MyAppName}
VersionInfoProductVersion={#MyAppVersion}
AlwaysShowComponentsList=false
#ifdef x64BitVersion
  ArchitecturesAllowed=x64
  ArchitecturesInstallIn64BitMode=x64
#endif
ChangesAssociations=Yes
UsePreviousAppDir=False

[Components]
Name: "MapWindow"; Description: "MapWindow5 files"; Types: full custom compact; Flags: fixed
Name: "USASampleData"; Description: "USA Sample data"; Types: full

[Files]
;; MapWinGIS
Source: "{#ExeBinPath}\MapWinGIS\*.*"; DestDir: "{app}\MapWinGIS"; Flags: ignoreversion recursesubdirs createallsubdirs {#SystemFlag}; Components: MapWindow; Excludes: "libecwj2.dll, *.exe, *.pdb"
;; MapWindow5 dlls
Source: "{#ExeBinPath}\*.dll"; DestDir: "{app}"; Flags: ignoreversion {#SystemFlag}; Components: MapWindow
Source: "{#ExeBinPath}\MapWindow.exe"; DestDir: "{app}"; Flags: ignoreversion {#SystemFlag}; Components: MapWindow
;; Manifest files:
Source: "{#ExeBinPath}\*.manifest"; DestDir: "{app}"; Flags: ignoreversion {#SystemFlag}; Components: MapWindow
;; Projections sub folder
Source: "{#ExeBinPath}\Projections\*"; DestDir: "{app}\Projections"; Flags: ignoreversion recursesubdirs createallsubdirs {#SystemFlag}; Components: MapWindow
;; Manuals sub folder
Source: "{#ExeBinPath}\Manuals\*"; DestDir: "{app}\Manuals"; Flags: ignoreversion recursesubdirs createallsubdirs {#SystemFlag}; Components: MapWindow
;; Plugins subfolder
Source: "{#ExeBinPath}\Plugins\*"; DestDir: "{app}\Plugins"; Flags: ignoreversion recursesubdirs createallsubdirs {#SystemFlag}; Components: MapWindow; Excludes: "AxInterop.MapWinGIS.dll,Interop.MapWinGIS.dll,MW5.TemplatePlugin.dll,Syncfusion.*"
;; Styles subfolder
Source: "{#ExeBinPath}\Styles\*"; DestDir: "{app}\Styles"; Flags: ignoreversion recursesubdirs createallsubdirs {#SystemFlag}; Components: MapWindow
;; SQLite interop:
#ifdef x64BitVersion
Source: "{#ExeBinPath}\x64\*"; DestDir: "{app}\x64"; Flags: ignoreversion {#SystemFlag}; Components: MapWindow
#else
Source: "{#ExeBinPath}\x86\*"; DestDir: "{app}\x86"; Flags: ignoreversion {#SystemFlag}; Components: MapWindow
#endif
;; Config files:
Source: "{#ExeBinPath}\MapWindow.exe.config"; DestDir: "{app}"; Flags: ignoreversion {#SystemFlag}; Components: MapWindow; Permissions: users-modify
;; Licenses
Source: "{#GdalLicensePath}\*.rtf"; DestDir: "{app}\Licenses"; Flags: ignoreversion; Components: MapWindow
Source: "{#ExeBinPath}\..\..\..\licenses\*"; DestDir: "{app}\Licenses"; Flags: ignoreversion {#SystemFlag}; Components: MapWindow

;; Sample data
Source: "{#SamplePath}\USA\*"; DestDir: "{code:GetDataDir}\USA"; Flags: recursesubdirs uninsneveruninstall; Components: USASampleData

;; VC++ files
Source: "{#vcredist}"; DestDir: "{tmp}"; Flags: deleteafterinstall ignoreversion {#SystemFlag}

;; Release notes:
Source: "{#ReleaseNotes}"; DestDir: "{app}"; Flags: ignoreversion; Components: MapWindow

; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Messages]
BeveledLabel={#MyAppName}

[Run]
; Install VC++ 2017 if needed:
#ifdef x64BitVersion
  Filename: "{tmp}\{#vcredist}"; Parameters: "/quiet"; Flags: waituntilterminated; Check: VCRedistNeedsInstall_x64()
#else
  Filename: "{tmp}\{#vcredist}"; Parameters: "/quiet"; Flags: waituntilterminated; Check: VCRedistNeedsInstall_x86()
#endif
Filename: "{app}\MapWindow.exe"; Flags: shellexec runasoriginaluser postinstall nowait skipifsilent; Description: "Start MapWindow5 GIS?"
Filename: "{code:GetDataDir}"; Flags: shellexec runasoriginaluser nowait skipifsilent; Description: "Open sample data folder"; Components: USASampleData
Filename: "{app}\ReleaseNotes.rtf"; Description: View the Release Notes; Flags: postinstall shellexec skipifsilent

[Icons]
;; In start menu:
Name: "{group}\{#MyAppName}"; Filename: "{app}\MapWindow.exe"; WorkingDir: "{app}"; Comment: "Start MapWindow5 GIS"; Components: MapWindow
;; On desktop:
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\MapWindow.exe"; WorkingDir: "{app}"; Comment: "Start MapWindow5 GIS"; Components: MapWindow

[Dirs]
Name: {code:GetDataDir}; Check: not DataDirExists; Flags: uninsneveruninstall; Permissions: users-modify
Name: "{app}\Logs"; Flags: uninsalwaysuninstall; Components: MapWindow; Permissions: users-modify
Name: "{app}\Styles"; Components: MapWindow; Permissions: users-modify
Name: "{app}\Projections"; Components: MapWindow; Permissions: users-modify

[UninstallDelete]
Type: filesandordirs; Name: "{app}\Logs"; Components: MapWindow

[Registry]
;; http://www.jrsoftware.org/isfaq.php#assoc
Root: "HKCR"; Subkey: ".mwproj"; ValueType: string; ValueData: "MW5Project"; Flags: uninsdeletevalue;
Root: "HKCR"; Subkey: "MW5Project"; ValueType: string; ValueData: "MW5 Project"; Flags: uninsdeletekey
Root: "HKCR"; Subkey: "MW5Project\DefaultIcon"; ValueType: string; ValueData: "{app}\MAPWINDOW.EXE,0"
Root: "HKCR"; Subkey: "MW5Project\shell\open\command"; ValueType: string; ValueData: """{app}\MAPWINDOW.EXE"" ""%1"""
Root: "HKCR"; Subkey: "MW5Project\"; ValueName: "InstallDir"; ValueType: string; ValueData: "{app}"

[InstallDelete]
Type: files; Name: "{app}\Plugins\MW5.TemplatePlugin.dll"; Components: MapWindow
Type: files; Name: "{app}\Plugins\Interop.MapWinGIS.dll"; Components: MapWindow
Type: files; Name: "{app}\Plugins\AxInterop.MapWinGIS.dll"; Components: MapWindow
;; Old ECW driver, conflicts with new driver:
Type: files; Name: "{app}\MapWinGIS\libecwj2.dll"; Components: MapWindow

[Code]
#IFDEF UNICODE
  #DEFINE AW "W"
#ELSE
  #DEFINE AW "A"
#ENDIF
type
  INSTALLSTATE = Longint;
const
  INSTALLSTATE_INVALIDARG = -2;  // An invalid parameter was passed to the function.
  INSTALLSTATE_UNKNOWN = -1;     // The product is neither advertised or installed.
  INSTALLSTATE_ADVERTISED = 1;   // The product is advertised but not installed.
  INSTALLSTATE_ABSENT = 2;       // The product is installed for a different user.
  INSTALLSTATE_DEFAULT = 5;      // The product is installed for the current user.

  VC_2008_REDIST_X86 = '{FF66E9F6-83E7-3A3E-AF14-8DE9A809A6A4}';
  VC_2008_REDIST_X64 = '{350AA351-21FA-3270-8B7A-835434E766AD}';
  VC_2008_REDIST_IA64 = '{2B547B43-DB50-3139-9EBE-37D419E0F5FA}';
  VC_2008_SP1_REDIST_X86 = '{9A25302D-30C0-39D9-BD6F-21E6EC160475}';
  VC_2008_SP1_REDIST_X64 = '{8220EEFE-38CD-377E-8595-13398D740ACE}';
  VC_2008_SP1_REDIST_IA64 = '{5827ECE1-AEB0-328E-B813-6FC68622C1F9}';
  VC_2008_SP1_ATL_SEC_UPD_REDIST_X86 = '{1F1C2DFC-2D24-3E06-BCB8-725134ADF989}';
  VC_2008_SP1_ATL_SEC_UPD_REDIST_X64 = '{4B6C7001-C7D6-3710-913E-5BC23FCE91E6}';
  VC_2008_SP1_ATL_SEC_UPD_REDIST_IA64 = '{977AD349-C2A8-39DD-9273-285C08987C7B}';
  VC_2008_SP1_MFC_SEC_UPD_REDIST_X86 = '{9BE518E6-ECC6-35A9-88E4-87755C07200F}';
  VC_2008_SP1_MFC_SEC_UPD_REDIST_X64 = '{5FCE6D76-F5DC-37AB-B2B8-22AB8CEDB1D4}';
  VC_2008_SP1_MFC_SEC_UPD_REDIST_IA64 = '{515643D1-4E9E-342F-A75A-D1F16448DC04}';

  VC_2010_REDIST_X86 = '{196BB40D-1578-3D01-B289-BEFC77A11A1E}';
  VC_2010_REDIST_X64 = '{DA5E371C-6333-3D8A-93A4-6FD5B20BCC6E}';
  VC_2010_REDIST_IA64 = '{C1A35166-4301-38E9-BA67-02823AD72A1B}';
  VC_2010_SP1_REDIST_X86 = '{F0C3E5D1-1ADE-321E-8167-68EF0DE699A5}';
  VC_2010_SP1_REDIST_X64 = '{1D8E6291-B0D5-35EC-8441-6616F567A0F7}';
  VC_2010_SP1_REDIST_IA64 = '{88C73C1C-2DE5-3B01-AFB8-B46EF4AB41CD}';

  // http://stackoverflow.com/questions/27582762/inno-setup-for-visual-c-redistributable-package-for-visual-studio-2013
  VC_2013_REDIST_X86 = '{13A4EE12-23EA-3371-91EE-EFB36DDFFF3E}'; //Microsoft.VS.VC_RuntimeMinimumVSU_x86,v12
  VC_2013_REDIST_X64 = '{A749D8E6-B613-3BE3-8F5F-045C84EBA29B}'; //Microsoft.VS.VC_RuntimeMinimumVSU_amd64,v12

  VC_2015_REDIST_X86 = '{8F271F6C-6E7B-3D0A-951B-6E7B694D78BD}'; //Microsoft.VS.VC_RuntimeMinimumVSU_x86,v14
  VC_2015_REDIST_X64 = '{221D6DB4-46E2-333C-B09B-5F49351D0980}'; //Microsoft.VS.VC_RuntimeMinimumVSU_amd64,v14


  // https://bell0bytes.eu/inno-setup-vc/
  // { Visual C++ 2017 Redistributable 14.16.27024 }
  VC_2017_REDIST_X86 = '{5EEFCEFB-E5F7-4C82-99A5-813F04AA4FBD}';
  VC_2017_REDIST_X64 = '{F1B0FB3A-E0EA-47A6-9383-3650655403B0}';

function MsiQueryProductState(szProduct: string): INSTALLSTATE; 
  external 'MsiQueryProductState{#AW}@msi.dll stdcall';

function VCVersionInstalled(const ProductID: string): Boolean;
begin
  Result := MsiQueryProductState(ProductID) = INSTALLSTATE_DEFAULT;
end;

function VCRedistNeedsInstall_x86(): Boolean;
begin
  // here the Result must be True when you need to install your VCRedist
  // or False when you don't need to, so now it's upon you how you build
  // this statement, the following won't install your VC redist only when
  // the Visual C++ 2008 Redist (x86) and Visual C++ 2008 SP1 Redist(x86)
  // are installed for the current user
  Result := not (VCVersionInstalled(VC_2017_REDIST_X86));
end;

function VCRedistNeedsInstall_x64(): Boolean;
begin
  // here the Result must be True when you need to install your VCRedist
  // or False when you don't need to, so now it's upon you how you build
  // this statement, the following won't install your VC redist only when
  // the Visual C++ 2008 Redist (x86) and Visual C++ 2008 SP1 Redist(x86)
  // are installed for the current user
  Result := not (VCVersionInstalled(VC_2017_REDIST_X64));
end;

function NeedsAddPath(Param: string): boolean;
var
  OrigPath: string;
begin
  if not RegQueryStringValue(HKEY_LOCAL_MACHINE,
    'SYSTEM\CurrentControlSet\Control\Session Manager\Environment',
    'Path', OrigPath)
  then begin
    Result := True;
    exit;
  end;
  // look for the path with leading and trailing semicolon
  // Pos() returns 0 if not found
  Result := Pos(';' + Param + ';', ';' + OrigPath + ';') = 0;
end;

// https://lindsaybradford.wordpress.com/2013/11/18/configurable-data-directories-via-inno-setup/
var
  DataDirPage: TInputDirWizardPage;
 
function GetDataDir(Param: String): String;
begin
  { Return the selected DataDir }
  Result := DataDirPage.Values[0];
end;
 

// custom wizard page setup, for data dir.
procedure InitializeWizard;
var
  myLocalAppData: String;
begin
  DataDirPage := CreateInputDirPage(
    wpSelectComponents,
    '{#MyAppName} Data Directory',
    '',
    'Please select a directory to install {#MyAppName} sample data to.',
    False,
    '{#MyAppName}'
  );
  DataDirPage.Add('Sample data dir');
 
  // Default data dir:
  DataDirPage.Values[0] := ExpandConstant('{userdocs}\MapWindow5');
end;

function DataDirExists(): Boolean;
begin
  { Find out if data dir already exists }
  Result := DirExists(GetDataDir(''));
end;

function ShouldSkipPage(PageID: Integer): Boolean;
begin
  // initialize result to not skip any page (not necessary, but safer)
  Result := False;
  // if the page that is asked to be skipped is your custom page, then...
  if PageID = DataDirPage.ID then
    // if the component is not selected, skip the page
    Result := not IsComponentSelected('USASampleData');
end;

function IsDotNetDetected(version: string; service: cardinal): boolean;
// From http://kynosarges.org/DotNetVersion.html
// Indicates whether the specified version and service pack of the .NET Framework is installed.
//
// version -- Specify one of these strings for the required .NET Framework version:
//    'v1.1'          .NET Framework 1.1
//    'v2.0'          .NET Framework 2.0
//    'v3.0'          .NET Framework 3.0
//    'v3.5'          .NET Framework 3.5
//    'v4\Client'     .NET Framework 4.0 Client Profile
//    'v4\Full'       .NET Framework 4.0 Full Installation
//    'v4.5'          .NET Framework 4.5
//    'v4.5.1'        .NET Framework 4.5.1
//    'v4.5.2'        .NET Framework 4.5.2
//    'v4.6'          .NET Framework 4.6
//    'v4.6.1'        .NET Framework 4.6.1
//
// service -- Specify any non-negative integer for the required service pack level:
//    0               No service packs required
//    1, 2, etc.      Service pack 1, 2, etc. required
var
    key, versionKey: string;
    install, release, serviceCount, versionRelease: cardinal;
    success: boolean;
begin
    versionKey := version;
    versionRelease := 0;

    // .NET 1.1 and 2.0 embed release number in version key
    if version = 'v1.1' then begin
        versionKey := 'v1.1.4322';
    end else if version = 'v2.0' then begin
        versionKey := 'v2.0.50727';
    end

    // .NET 4.5 and newer install as update to .NET 4.0 Full
    else if Pos('v4.', version) = 1 then begin
        versionKey := 'v4\Full';
        case version of
          'v4.5':   versionRelease := 378389;
          'v4.5.1': versionRelease := 378675; // or 378758 on Windows 8 and older
          'v4.5.2': versionRelease := 379893;
          'v4.6':   versionRelease := 393295; // or 393297 on Windows 8.1 and older
          'v4.6.1': versionRelease := 394254; // or 394271 on Windows 8.1 and older
        end;
    end;

    // installation key group for all .NET versions
    key := 'SOFTWARE\Microsoft\NET Framework Setup\NDP\' + versionKey;

    // .NET 3.0 uses value InstallSuccess in subkey Setup
    if Pos('v3.0', version) = 1 then begin
        success := RegQueryDWordValue(HKLM, key + '\Setup', 'InstallSuccess', install);
    end else begin
        success := RegQueryDWordValue(HKLM, key, 'Install', install);
    end;

    // .NET 4.0 and newer use value Servicing instead of SP
    if Pos('v4', version) = 1 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Servicing', serviceCount);
    end else begin
        success := success and RegQueryDWordValue(HKLM, key, 'SP', serviceCount);
    end;

    // .NET 4.5 and newer use additional value Release
    if versionRelease > 0 then begin
        success := success and RegQueryDWordValue(HKLM, key, 'Release', release);
        success := success and (release >= versionRelease);
    end;

    result := success and (install = 1) and (serviceCount >= service);
end;

function InitializeSetup(): Boolean;
begin
    if not IsDotNetDetected('v4.6', 0) then begin
        MsgBox('MapWindow5 requires Microsoft .NET Framework 4.6.'#13#13
            'Please use Windows Update to install this version,'#13
            'and then re-run this setup program.', mbInformation, MB_OK);
        result := false;
    end else
        result := true;
end;

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
;;Name: "afrikaans"; MessagesFile: "compiler:Languages\Afrikaans.isl"
;;Name: "albanian"; MessagesFile: "compiler:Languages\Albanian.isl"
;;Name: "arabic"; MessagesFile: "compiler:Languages\Arabic.isl"
;;Name: "basque"; MessagesFile: "compiler:Languages\Basque.isl"
;;Name: "belarusian"; MessagesFile: "compiler:Languages\Belarusian.isl"
;;Name: "bosnian"; MessagesFile: "compiler:Languages\Bosnian.isl"
Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
;;Name: "bulgarian"; MessagesFile: "compiler:Languages\Bulgarian.isl"
Name: "catalan"; MessagesFile: "compiler:Languages\Catalan.isl"
;;Name: "chinesesimp"; MessagesFile: "compiler:Languages\ChineseSimplified.isl"
;;Name: "chinesetrad"; MessagesFile: "compiler:Languages\ChineseTraditional.isl"
Name: "corsican"; MessagesFile: "compiler:Languages\Corsican.isl"
Name: "czech"; MessagesFile: "compiler:Languages\Czech.isl"
Name: "danish"; MessagesFile: "compiler:Languages\Danish.isl"
Name: "dutch"; MessagesFile: "compiler:Languages\Dutch.isl"
;;Name: "estonian"; MessagesFile: "compiler:Languages\Estonian.isl"
Name: "finnish"; MessagesFile: "compiler:Languages\Finnish.isl"
Name: "french"; MessagesFile: "compiler:Languages\French.isl"
;;Name: "galician"; MessagesFile: "compiler:Languages\Galician.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"
;;Name: "greek"; MessagesFile: "compiler:Languages\Greek.isl"
Name: "hebrew"; MessagesFile: "compiler:Languages\Hebrew.isl"
;;Name: "hungarian"; MessagesFile: "compiler:Languages\Hungarian.isl"
Name: "icelandic"; MessagesFile: "compiler:Languages\Icelandic.isl"
;;Name: "indonesian"; MessagesFile: "compiler:Languages\Indonesian.isl"
Name: "italian"; MessagesFile: "compiler:Languages\Italian.isl"
Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"
;;Name: "korean"; MessagesFile: "compiler:Languages\Korean.isl"
;;Name: "lithuanian"; MessagesFile: "compiler:Languages\Lithuanian.isl"
;;Name: "luxemburgish"; MessagesFile: "compiler:Languages\Luxemburgish.isl"
;;Name: "macedonian"; MessagesFile: "compiler:Languages\Macedonian.isl"
;;Name: "malaysian"; MessagesFile: "compiler:Languages\Malaysian.isl"
;;Name: "nepali"; MessagesFile: "compiler:Languages\Nepali.islu"
Name: "norwegian"; MessagesFile: "compiler:Languages\Norwegian.isl"
Name: "polish"; MessagesFile: "compiler:Languages\Polish.isl"
Name: "portuguese"; MessagesFile: "compiler:Languages\Portuguese.isl"
;;Name: "romanian"; MessagesFile: "compiler:Languages\Romanian.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"
;;Name: "serbiancyrillic"; MessagesFile: "compiler:Languages\SerbianCyrillic.isl"
;;Name: "serbianlatin"; MessagesFile: "compiler:Languages\SerbianLatin.isl"
;;Name: "slovak"; MessagesFile: "compiler:Languages\Slovak.isl"
Name: "slovenian"; MessagesFile: "compiler:Languages\Slovenian.isl"
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"
;;Name: "swedish"; MessagesFile: "compiler:Languages\Swedish.isl"
;;Name: "tatarish"; MessagesFile: "compiler:Languages\Tatar.isl"
Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"
Name: "ukrainian"; MessagesFile: "compiler:Languages\Ukrainian.isl"
