<?php
//kiem tra dang nhap
use \Firebase\JWT\JWT;
require __DIR__ . '/vendor/autoload.php';
include('function.php');
include('connect/connect.php');
$json = file_get_contents('php://input');
$obj = json_decode($json, true);
$token = $obj['token'];
$key = "tuanduong_2909";

try{
	$decoded = JWT::decode($token, $key, array('HS256'));
	if($decoded->expire < time()){
		echo 'HET_HAN';
	}
	else{
		$jwt = getToken($decoded->username);
		$decoded = JWT::decode($jwt, $key, array('HS256'));
		$username = $decoded->username;
		$sql = "SELECT * FROM TaiKhoan where Username = '$username'";
		
		$stmt = sqlsrv_query( $conn, $sql);
		if( $stmt === false ) {
			 die( print_r( sqlsrv_errors(), true));
		}

		$user = sqlsrv_fetch_array( $stmt, SQLSRV_FETCH_ASSOC);

		if($user){
			$jwt = getToken($username);
			$array = array('token'=>$jwt, 'user'=>$user);
			print_r(json_encode($array));
		}
	}
}
catch(Exception $e){
	echo 'TOKEN_KHONG_HOP_LE';
}

?>