<?php
//dang nhap
use \Firebase\JWT\JWT;
require __DIR__ . '/vendor/autoload.php';
include('function.php');
include('connect/connect.php');

$key = "tuanduong_2909";

$json = file_get_contents('php://input');
$obj = json_decode($json, true);

$username = $obj['username'];
$password = $obj['password'];

//Kiểm tra kết nối sql server
if( $conn === false ) {
     die( print_r( sqlsrv_errors(), true));
}
//Câu truy vẫn
$sql = "SELECT Username, DisplayName FROM TaiKhoan where Username = '$username' and PassWord = '$password'";
$stmt = sqlsrv_query( $conn, $sql);

if( $stmt === false ) {
     die( print_r( sqlsrv_errors(), true));
}

//mock user từ sql
$user = sqlsrv_fetch_array( $stmt, SQLSRV_FETCH_ASSOC);

if($user){
	$jwt = getToken($username);
	$array = array('token'=>$jwt, 'username'=>$user['Username'],'displayName'=>$user['DisplayName']);
	print_r(json_encode($array));
}
else{
	echo 'SAI_THONG_TIN_DANG_NHAP';
}

?>