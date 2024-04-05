<?php
use \Firebase\JWT\JWT;
require __DIR__ . '/vendor/autoload.php';
include('function.php');
include('connect/connect.php');

$key = "tuanduong_2909";

$json = file_get_contents('php://input');
$obj = json_decode($json, true);
$token = $obj['token'];
$idTable = $obj['idTable'];

try{
	$decoded = JWT::decode($token, $key, array('HS256'));
	if($decoded->expire < time()){
		echo 'HET_HAN';
	}
	else{
		
		$username = $decoded->username;

		$sql = "INSERT INTO HOADON (idTable) values ($idTable);";
		$stmt = sqlsrv_query( $conn, $sql);
		
		//Lay max
		$sqlMax = "SELECT MAX(ID) as MaxID FROM HOADON";
		$stmtMax = sqlsrv_query( $conn, $sqlMax);
		if( $stmtMax === false ) {
			 echo 'KHONG_THANH_CONG';
		}
		
		//mock user từ sql
		$bill = sqlsrv_fetch_array( $stmtMax, SQLSRV_FETCH_ASSOC);
		
		
		if($bill){
			print_r(json_encode($bill, true));
		}
		else{
			echo 'KHONG_THANH_CONG';
		}

	}
}

catch(Exception $e){
	echo 'LOI';
}
?>