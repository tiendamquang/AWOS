Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Microsoft.ApplicationBlocks.Data
Public Class clsUserDA
    Private _userID As Integer
    Private _userName As String
    Private _password As String
    Private _displayName As String
    Private _groupID As Integer
    Private _email As String
    Private _gender As Integer
    Private _dateOfBirth As String
    Private _cMND As String
    Private _phoneNumber As String
    Private _notes As String
    Private _status As Integer
    Private _createTime As String
    Private _createDate As String

    Public Sub clsUserDA()
    End Sub

    Public Property UserID As Integer
        Get
            Return _userID
        End Get
        Set(ByVal value As Integer)
            _userID = value
        End Set
    End Property
    Public Property UserName As String
        Get
            Return _userName
        End Get
        Set(ByVal value As String)
            _userName = value
        End Set
    End Property
    Public Property Password As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property


    Public Property DisplayName As String
        Get
            Return _displayName
        End Get
        Set(ByVal value As String)
            _displayName = value
        End Set
    End Property
    Public Property GroupID As Integer
        Get
            Return _groupID
        End Get
        Set(ByVal value As Integer)
            _groupID = value
        End Set
    End Property
    Public Property Email As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property
    Public Property Gender As Integer
        Get
            Return _gender
        End Get
        Set(ByVal value As Integer)
            _gender = value
        End Set
    End Property
    Public Property DateOfBirth As String
        Get
            Return _dateOfBirth
        End Get
        Set(ByVal value As String)
            _dateOfBirth = value
        End Set
    End Property
    Public Property CMND As String
        Get
            Return _cMND
        End Get
        Set(ByVal value As String)
            _cMND = value
        End Set
    End Property
    Public Property PhoneNumber As String
        Get
            Return _phoneNumber
        End Get
        Set(ByVal value As String)
            _phoneNumber = value
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
    Public Property Status As Integer
        Get
            Return _status
        End Get
        Set(ByVal value As Integer)
            _status = value
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
