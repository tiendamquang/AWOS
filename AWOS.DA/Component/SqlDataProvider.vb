Imports System
Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Public Class SqlDataProvider
#Region "Private Static"
    Private Shared _connectionString As String
    Private Shared _sqlConnection As SqlConnection
    Private Shared _sqlCommand As SqlCommand
    Private Shared _sqlDataAdapter As SqlDataAdapter
#End Region

    Public Sub New()
    End Sub
    Public Sub New(ByVal _i_connectionString As String)
        _connectionString = _i_connectionString
    End Sub
#Region "Private Methods"
    Public Shared Function GetConnectionString() As String
        Dim _result As String = "Data Source=" & RegistryHelper.GetSetting("AWOS", "IPServer", "10.100.100.235").ToString() & ";Initial Catalog=" + RegistryHelper.GetSetting("AWOS", "Database", "AWOS").ToString() & ";UID=sa;PWD=alsb!!52019;"
        Return _result
    End Function
    Private Shared Sub AssignParameters(ByVal _cmd As SqlCommand, ByVal _cmdParameters As SqlParameter())
        If _cmdParameters Is Nothing Then Return

        For Each _p As SqlParameter In _cmdParameters
            _cmd.Parameters.Add(_p)
        Next
    End Sub
    Private Shared Sub AssignParameters(ByVal _cmd As SqlCommand, ByVal _parametersValue As Object())
        If _cmd.Parameters.Count - 1 <> _parametersValue.Length Then
            Throw New ApplicationException("Stored procedure's parameters and parameter values does not match.")
        End If

        Dim i As Integer = 0

        For Each _param As SqlParameter In _cmd.Parameters

            If _param.Direction <> ParameterDirection.Output AndAlso _param.Direction <> ParameterDirection.ReturnValue Then
                _param.Value = _parametersValue(i)
                i = i + 1
            End If
        Next
    End Sub
    Private Shared Sub OpenConnection()
        _connectionString = GetConnectionString()
        _sqlConnection = New SqlConnection(_connectionString)
        If _sqlConnection.State = ConnectionState.Closed Then _sqlConnection.Open()
    End Sub
    Private Shared Sub CloseConnection()
        If _sqlConnection.State = ConnectionState.Open Then _sqlConnection.Close()
    End Sub
    Private Shared Sub CreateCommand(ByVal _procedureName As String)
        _sqlCommand = New SqlCommand()
        _sqlCommand.Connection = _sqlConnection
        _sqlCommand.CommandType = CommandType.StoredProcedure
        _sqlCommand.CommandText = _procedureName
    End Sub
    Private Shared Sub CreateCommand(ByVal _procedureName As String, ParamArray _paramValues As Object())
        _sqlCommand = New SqlCommand()
        _sqlCommand.Connection = _sqlConnection
        _sqlCommand.CommandType = CommandType.StoredProcedure
        _sqlCommand.CommandText = _procedureName
        SqlCommandBuilder.DeriveParameters(_sqlCommand)
        AssignParameters(_sqlCommand, _paramValues)
    End Sub
    Private Shared Sub CreateCommandEx(ByVal _sqlQuery As String)
        _sqlCommand = New SqlCommand()
        _sqlCommand.Connection = _sqlConnection
        _sqlCommand.CommandType = CommandType.Text
        _sqlCommand.CommandText = _sqlQuery
    End Sub
    Private Shared Sub CreateCommandEx(ByVal _sqlQuery As String, ParamArray _paramValues As Object())
        _sqlCommand = New SqlCommand()
        _sqlCommand.Connection = _sqlConnection
        _sqlCommand.CommandType = CommandType.Text
        _sqlCommand.CommandText = _sqlQuery
        SqlCommandBuilder.DeriveParameters(_sqlCommand)
        AssignParameters(_sqlCommand, _paramValues)
    End Sub
    Private Shared Sub DisposeCommand()
        _sqlCommand.Dispose()
    End Sub
#End Region
#Region "ExecuteNonQuery"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_procedureName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteNonQueryP(ByVal _procedureName As String) As Integer
        OpenConnection()
        CreateCommand(_procedureName)
        _sqlCommand.CommandTimeout = 0
        Dim _result As Integer = _sqlCommand.ExecuteNonQuery()
        DisposeCommand()
        CloseConnection()
        Return _result
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_procedureName"></param>
    ''' <param name="_parametersValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteNonQueryP(ByVal _procedureName As String, ParamArray _parametersValue As Object()) As Integer
        OpenConnection()
        CreateCommand(_procedureName, _parametersValue)
        _sqlCommand.CommandTimeout = 0
        Dim _result As Integer = _sqlCommand.ExecuteNonQuery()
        DisposeCommand()
        CloseConnection()
        Return _result
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_queryString"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteNonQueryT(ByVal _queryString As String) As Integer
        OpenConnection()
        CreateCommandEx(_queryString)
        _sqlCommand.CommandTimeout = 0
        Dim _result As Integer = _sqlCommand.ExecuteNonQuery()
        DisposeCommand()
        CloseConnection()
        Return _result
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_queryString"></param>
    ''' <param name="_parametersValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ExecuteNonQueryT(ByVal _queryString As String, ParamArray _parametersValue As Object()) As Integer
        OpenConnection()
        CreateCommandEx(_queryString, _parametersValue)
        _sqlCommand.CommandTimeout = 0
        Dim _result As Integer = _sqlCommand.ExecuteNonQuery()
        DisposeCommand()
        CloseConnection()
        Return _result
    End Function
#End Region
#Region "ExecuteScalar"
    Public Shared Function ExecuteScalarP(ByVal _procedureName As String) As Object
        OpenConnection()
        CreateCommand(_procedureName)
        Dim _result As Object = _sqlCommand.ExecuteScalar()
        DisposeCommand()
        CloseConnection()
        Return _result
    End Function
    Public Shared Function ExecuteScalarP(ByVal _procedureName As String, ParamArray _paramsValue As Object()) As Object
        OpenConnection()
        CreateCommand(_procedureName, _paramsValue)
        Dim _result As Object = _sqlCommand.ExecuteScalar()
        DisposeCommand()
        CloseConnection()
        Return _result
    End Function
    Public Shared Function ExecuteScalarT(ByVal _queryString As String) As Object
        OpenConnection()
        CreateCommandEx(_queryString)
        Dim _result As Object = _sqlCommand.ExecuteScalar()
        DisposeCommand()
        CloseConnection()
        Return _result
    End Function
    Public Shared Function ExecuteScalarT(ByVal _procedureName As String, ParamArray _paramsValue As Object()) As Object
        OpenConnection()
        CreateCommandEx(_procedureName, _paramsValue)
        Dim _result As Object = _sqlCommand.ExecuteScalar()
        DisposeCommand()
        CloseConnection()
        Return _result
    End Function
#End Region
#Region "ExecuteDataReader"
    Public Shared Function ExecuteDataReaderP(ByVal _procedureName As String) As IDataReader
        OpenConnection()
        CreateCommand(_procedureName)
        Dim _result As SqlDataReader = _sqlCommand.ExecuteReader()
        DisposeCommand()
        CloseConnection()
        Return (CType(_result, IDataReader))
    End Function

    Public Shared Function ExecuteDataReaderP(ByVal _procedureName As String, ParamArray _paramsValue As Object()) As IDataReader
        OpenConnection()
        CreateCommand(_procedureName, _paramsValue)
        Dim _result As SqlDataReader = _sqlCommand.ExecuteReader()
        DisposeCommand()
        CloseConnection()
        Return (CType(_result, IDataReader))
    End Function
    Public Shared Function ExecuteDataReaderT(ByVal _queryString As String) As IDataReader
        OpenConnection()
        CreateCommandEx(_queryString)
        Dim _result As SqlDataReader = _sqlCommand.ExecuteReader()
        DisposeCommand()
        CloseConnection()
        Return (CType(_result, IDataReader))
    End Function
    Public Shared Function ExecuteDataReaderT(ByVal _procedureName As String, ParamArray _paramsValue As Object()) As IDataReader
        OpenConnection()
        CreateCommandEx(_procedureName, _paramsValue)
        Dim _result As SqlDataReader = _sqlCommand.ExecuteReader()
        DisposeCommand()
        CloseConnection()
        Return (CType(_result, IDataReader))
    End Function
#End Region
#Region "ExecuteDataSet"
    Public Shared Function ExecuteDataSetP(ByVal _procedureName As String) As DataSet
        Dim _ds As DataSet = New DataSet()
        OpenConnection()
        CreateCommand(_procedureName)
        _sqlCommand.CommandTimeout = 0
        _sqlCommand.ExecuteNonQuery()
        _sqlDataAdapter = New SqlDataAdapter(_sqlCommand)
        _sqlDataAdapter.Fill(_ds)
        _sqlDataAdapter.Dispose()
        DisposeCommand()
        CloseConnection()
        Return _ds
    End Function

    Public Shared Function ExecuteDataSetP(ByVal _procedureName As String, ParamArray _paramsValue As Object()) As DataSet
        Dim _ds As DataSet = New DataSet()
        OpenConnection()
        CreateCommand(_procedureName, _paramsValue)
        _sqlCommand.CommandTimeout = 0
        _sqlCommand.ExecuteNonQuery()
        _sqlDataAdapter = New SqlDataAdapter(_sqlCommand)
        _sqlDataAdapter.Fill(_ds)
        _sqlDataAdapter.Dispose()
        DisposeCommand()
        CloseConnection()
        Return _ds
    End Function
    Public Shared Function ExecuteDataSetT(ByVal _queryString As String) As DataSet
        Dim _ds As DataSet = New DataSet()
        OpenConnection()
        CreateCommandEx(_queryString)
        _sqlCommand.CommandTimeout = 0
        _sqlCommand.ExecuteNonQuery()
        _sqlDataAdapter = New SqlDataAdapter(_sqlCommand)
        _sqlDataAdapter.Fill(_ds)
        _sqlDataAdapter.Dispose()
        DisposeCommand()
        CloseConnection()
        Return _ds
    End Function
    Public Shared Function ExecuteDataSetT(ByVal _queryString As String, ParamArray _paramsValue As Object()) As DataSet
        Dim _ds As DataSet = New DataSet()
        OpenConnection()
        CreateCommandEx(_queryString, _paramsValue)
        _sqlCommand.CommandTimeout = 0
        _sqlCommand.ExecuteNonQuery()
        _sqlDataAdapter = New SqlDataAdapter(_sqlCommand)
        _sqlDataAdapter.Fill(_ds)
        _sqlDataAdapter.Dispose()
        DisposeCommand()
        CloseConnection()
        Return _ds
    End Function

#End Region


End Class
