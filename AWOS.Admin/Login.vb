
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

Public Class Login
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Dim objBO As clsUserBO = New clsUserBO()
        If txtusername.Text.Equals("") Then
            MessageBox.Show("UserName is not Empty!!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            txtusername.Focus()
        ElseIf txtpassword.Text.Equals("") Then
            MessageBox.Show("PassWord is not Empty!!", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            txtpassword.Focus()
        Else
            If objBO.sp_UserGetExist(txtusername.Text.Trim(), txtpassword.Text.Trim()) = True Then
                clsParameter.strUsrName = txtusername.Text.Trim()
                '' MessageBox.Show("User OK " + txtusername.Text.Trim(), "Infomation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Dim frm As Admin = New Admin()
                frm.ShowDialog()
            Else
                MessageBox.Show("User Or Password Wrong. Please Check Again!!", "Infomation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            End If
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            RegistryHelper.SaveSetting("AWOS", "IPServer", "192.168.2.14")
            RegistryHelper.SaveSetting("AWOS", "Database", "AWOS")
            'MessageBox.Show(clsParameter.strNotifySuccess, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
