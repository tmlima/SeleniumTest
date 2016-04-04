#Region ;**** Directives created by AutoIt3Wrapper_GUI ****
#AutoIt3Wrapper_Outfile=problema2.exe
#EndRegion ;**** Directives created by AutoIt3Wrapper_GUI ****
#include <Word.au3>
#include <FileConstants.au3>
#include <MsgBoxConstants.au3>
#include <WinAPIFiles.au3>
#include <ScreenCapture.au3>
#include <Date.au3>

Local $timestamp = @YEAR & @MON & @MDAY & "_" & @HOUR & @MIN & @SEC & @MSEC
Local $path = $CmdLine[1]
Global $logFile = $path & "\" & $CmdLine[2]
WriteLog("Opening notepad")
Run("notepad.exe " & $path & "\" & "fake.txt")
Local $fileContent = FileRead($path & "\" & "fake.txt")

WinWaitActive("fake.txt")
WriteLog("Coping content")
Send("^a")
Send("^c")
WriteLog("Closing notepad")
WinClose("fake.txt")

WriteLog("Opening word")
Local $oWord = _Word_Create()
WriteLog("Creating word document")
Local $oDoc = _Word_DocAdd($oWord)
WinActivate($oDoc.Name & " - Word")
WinSetState($oDoc.Name & " - Word", "", @SW_MAXIMIZE)

WriteLog("Pasting content")
Send("^v")
Sleep(3000)
Local $fileName = "Word_" & $timestamp
WriteLog("Taking screenshot")
_ScreenCapture_Capture($path & "\" & $fileName & ".jpg")

WriteLog("Saving word document")
_Word_DocSaveAs($oDoc, $path & "\" & $fileName & ".doc")
WriteLog("Quitting word")
_Word_Quit($oWord)

$oWord = _Word_Create()
$oDoc = _Word_DocOpen($oWord, $path & "\" & $fileName & ".doc")
WinActivate($oDoc.Name & " - Word")
$oDoc.Range.WholeStory()
$oDoc.Range.Copy()
$wordFileContent = ClipGet()
If StringCompare($fileContent, $wordFileContent) == 0 Then
	WriteLog("Test successfully")
Else
	WriteLog("ERROR: Fake.txt content not found in doc file")
EndIf

_Word_Quit($oWord)

Func WriteLog($message)
	FileWriteLine($logFile, "[" & @HOUR & @MIN & @SEC & @MSEC & "] " & $message)
EndFunc