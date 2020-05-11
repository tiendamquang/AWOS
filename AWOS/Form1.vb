Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports AWOS.BO
Imports AWOS.DA
Imports System.IO
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RegistryHelper.SaveSetting("CHSSystem", "IPServer", "10.100.100.235")
            RegistryHelper.SaveSetting("CHSSystem", "Database", "AWOS")

            'Dim objBO As clsUserBO = New clsUserBO()
            'Dim strUser As String = "admin"
            'If objBO.UserGetExist(strUser) = True Then
            '    'clsParameter.strUsrName = txtusername.Text.Trim()
            '    '' MessageBox.Show("User OK " + txtusername.Text.Trim(), "Infomation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            '    'Dim frm As Main = New Main()
            '    'frm.ShowDialog()
            '    Label1.Text = strUser
            'Else
            '    MessageBox.Show("User NOT OK. Please Check Again!!", "Infomation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            'End If
            'MessageBox.Show(clsParameter.strNotifySuccess, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
