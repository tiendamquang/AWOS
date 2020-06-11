Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports AWOS.DA
Imports System.Data

Public Class clsUserBO
    Inherits AWOS.DA.SqlDataProvider
    Public Function sp_UserGetExist(ByVal UserName As String, ByVal Password As String) As Boolean
        If ExecuteDataSetP("sp_UserGetExist", UserName, Password).Tables(0).Rows.Count > 0 Then
            Return True
        End If

        Return False
    End Function

End Class
