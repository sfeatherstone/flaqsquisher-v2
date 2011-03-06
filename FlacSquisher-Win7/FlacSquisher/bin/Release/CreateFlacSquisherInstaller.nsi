; Script generated by the HM NIS Edit Script Wizard.

; HM NIS Edit Wizard helper defines
!define PRODUCT_NAME "FlacSquisher"
!define PRODUCT_VERSION "1.0.5"
!define PRODUCT_PUBLISHER "FlacSquisher"
!define PRODUCT_WEB_SITE "http://sourceforge.net/projects/flacsquisher/"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\FlacSquisher.exe"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

; MUI 1.67 compatible ------
!include "MUI.nsh"

; MUI Settings
!define MUI_ABORTWARNING
!define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\modern-install.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

; Welcome page
!insertmacro MUI_PAGE_WELCOME
; License page
!insertmacro MUI_PAGE_LICENSE "C:\Documents and Settings\Mike\My Documents\Visual Studio 2008\Projects\FlacSquisher\FlacSquisher\LICENSE.txt"
; Directory page
!insertmacro MUI_PAGE_DIRECTORY
; Instfiles page
!insertmacro MUI_PAGE_INSTFILES
; Finish page
!define MUI_FINISHPAGE_RUN "$INSTDIR\FlacSquisher.exe"
Function finishpageaction
CreateShortcut "$DESKTOP\FlacSquisher.lnk" "$INSTDIR\FlacSquisher.exe"
FunctionEnd
!define MUI_FINISHPAGE_SHOWREADME ""
!define MUI_FINISHPAGE_SHOWREADME_NOTCHECKED
!define MUI_FINISHPAGE_SHOWREADME_TEXT "Create Desktop Shortcut"
!define MUI_FINISHPAGE_SHOWREADME_FUNCTION finishpageaction

!insertmacro MUI_PAGE_FINISH

; Uninstaller pages
!insertmacro MUI_UNPAGE_INSTFILES

; Language files
!insertmacro MUI_LANGUAGE "English"

; MUI end ------

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "FlacSquisher-Win7-install.exe"
InstallDir "$PROGRAMFILES\FlacSquisher"
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""
ShowInstDetails show
ShowUnInstDetails show

Section "MainSection" SEC01
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  CreateDirectory "$SMPROGRAMS\FlacSquisher"
  CreateShortCut "$SMPROGRAMS\FlacSquisher\FlacSquisher.lnk" "$INSTDIR\FlacSquisher.exe"
  File "C:\Documents and Settings\Mike\My Documents\Visual Studio 2008\Projects\FlacSquisher\FlacSquisher-Win7\FlacSquisher\bin\Release\metaflac.exe"
  File "C:\Documents and Settings\Mike\My Documents\Visual Studio 2008\Projects\FlacSquisher\FlacSquisher-Win7\FlacSquisher\bin\Release\libsndfile-1.dll"
  File "C:\Documents and Settings\Mike\My Documents\Visual Studio 2008\Projects\FlacSquisher\FlacSquisher-Win7\FlacSquisher\bin\Release\lame.exe"
  File "C:\Documents and Settings\Mike\My Documents\Visual Studio 2008\Projects\FlacSquisher\FlacSquisher-Win7\FlacSquisher\bin\Release\flac.exe"
  File "C:\Documents and Settings\Mike\My Documents\Visual Studio 2008\Projects\FlacSquisher\FlacSquisher-Win7\FlacSquisher\bin\Release\oggenc.exe"
  File "C:\Documents and Settings\Mike\My Documents\Visual Studio 2008\Projects\FlacSquisher\FlacSquisher-Win7\FlacSquisher\bin\Release\Microsoft.WindowsAPICodePack.dll"
  File "C:\Documents and Settings\Mike\My Documents\Visual Studio 2008\Projects\FlacSquisher\FlacSquisher-Win7\FlacSquisher\bin\Release\Microsoft.WindowsAPICodePack.Shell.dll"
  SetOverwrite on
  File "C:\Documents and Settings\Mike\My Documents\Visual Studio 2008\Projects\FlacSquisher\FlacSquisher-Win7\FlacSquisher\bin\Release\FlacSquisher.exe"
SectionEnd

Section -AdditionalIcons
  WriteIniStr "$INSTDIR\${PRODUCT_NAME}.url" "InternetShortcut" "URL" "${PRODUCT_WEB_SITE}"
  CreateShortCut "$SMPROGRAMS\FlacSquisher\Website.lnk" "$INSTDIR\${PRODUCT_NAME}.url"
  CreateShortCut "$SMPROGRAMS\FlacSquisher\Uninstall.lnk" "$INSTDIR\uninst.exe"
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\FlacSquisher.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\FlacSquisher.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
SectionEnd


Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) was successfully removed from your computer."
FunctionEnd

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "Are you sure you want to completely remove $(^Name) and all of its components?" IDYES +2
  Abort
FunctionEnd

Section Uninstall
  Delete "$INSTDIR\${PRODUCT_NAME}.url"
  Delete "$INSTDIR\uninst.exe"
  Delete "$INSTDIR\FlacSquisher.exe"
  Delete "$INSTDIR\oggenc.exe"
  Delete "$INSTDIR\flac.exe"
  Delete "$INSTDIR\lame.exe"
  Delete "$INSTDIR\libsndfile-1.dll"
  Delete "$INSTDIR\metaflac.exe"

  Delete "$SMPROGRAMS\FlacSquisher\Uninstall.lnk"
  Delete "$SMPROGRAMS\FlacSquisher\Website.lnk"
  Delete "$DESKTOP\FlacSquisher.lnk"
  Delete "$SMPROGRAMS\FlacSquisher\FlacSquisher.lnk"

  RMDir "$SMPROGRAMS\FlacSquisher"
  RMDir "$INSTDIR"

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
  SetAutoClose true
SectionEnd
