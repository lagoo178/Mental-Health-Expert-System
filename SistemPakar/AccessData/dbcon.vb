Imports MySql.Data.MySqlClient

Module dbcon

    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public rd As MySqlDataReader
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public lokasidata As String

    'variabel tabel tanda
    Public drtanda As mysqlDataReader
    Public comtanda As MySqlCommand
    Public datanda As MySqlDataAdapter
    Public dttanda As DataTable

    'variabel tabel test
    Public drtest As MySqlDataReader
    Public comtest As MySqlCommand
    Public datest As MySqlDataAdapter
    Public dttest As DataTable

    'variabel tabel aturan
    Public draturan As MySqlDataReader
    Public comaturan As MySqlCommand
    Public daaturan As MySqlDataAdapter
    Public dtaturan As DataTable

    Public draturan2 As MySqlDataReader
    Public comaturan2 As MySqlCommand
    Public daaturan2 As MySqlDataAdapter
    Public dtaturan2 As DataTable

    'vaiable login & sign up
    Public drlogin As MySqlDataReader
    Public cologin As MySqlCommand
    Public dalogin As MySqlDataAdapter
    Public dtlogin As DataTable


End Module

