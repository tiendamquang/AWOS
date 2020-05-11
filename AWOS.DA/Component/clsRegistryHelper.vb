Imports System
Imports Microsoft.Win32
Imports System.Windows.Forms


Public Class RegistryHelper
    Private Shared Function FormRegKey(ByVal sSect As String) As String
        Return sSect
    End Function
    Public Shared Sub SaveSetting(ByVal Section As String, ByVal Key As String, ByVal Setting As String)
        Dim text1 As String = FormRegKey(Section)
        Dim key1 As RegistryKey = Application.UserAppDataRegistry.CreateSubKey(text1)

        If key1 Is Nothing Then
            Return
        End If

        Try
            key1.SetValue(Key, Setting)
        Catch exception1 As Exception
            Return
        Finally
            key1.Close()
        End Try
    End Sub
    Public Shared Function GetSetting(ByVal Section As String, ByVal Key As String, ByVal [Default] As String) As String
        If [Default] Is Nothing Then
            [Default] = ""
        End If

        Dim text2 As String = FormRegKey(Section)
        Dim key1 As RegistryKey = Application.UserAppDataRegistry.OpenSubKey(text2)

        If key1 IsNot Nothing Then
            Dim obj1 As Object = key1.GetValue(Key, [Default])
            key1.Close()

            If obj1 IsNot Nothing Then

                If Not (TypeOf obj1 Is String) Then
                    Return Nothing
                End If

                Return CStr(obj1)
            End If

            Return Nothing
        End If

        Return [Default]
    End Function
End Class
