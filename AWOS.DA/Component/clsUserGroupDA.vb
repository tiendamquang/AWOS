Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Public Class clsUserGroupDA
    Private _groupID As Integer
    Private _groupName As String
    Private _notes As String
    Private _createTime As String
    Private _createDate As String
    Public Sub clsUserGroupDA()
    End Sub

    Public Property GroupID As Integer
        Get
            Return _groupID
        End Get
        Set(ByVal value As Integer)
            _groupID = value
        End Set
    End Property
    Public Property Notes As String
        Get
            Return _notes
        End Get
        Set(ByVal value As String)
            _notes = value
        End Set
    End Property
    Public Property CreateTime As String
        Get
            Return _createTime
        End Get
        Set(ByVal value As String)
            _createTime = value
        End Set
    End Property
    Public Property CreateDate As String
        Get
            Return _createDate
        End Get
        Set(ByVal value As String)
            _createDate = value
        End Set
    End Property
End Class
