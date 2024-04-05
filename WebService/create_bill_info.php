<?php
use \Firebase\JWT\JWT;
require __DIR__ . '/vendor/autoload.php';
include('function.php');
include('connect/connect.php');

$key = "tuanduong_2909";

$json = file_get_contents('php://input');
$obj = json_decode($json, true);
$token = $obj['token'];
$idBill = $obj['idBill'];
$list = (array) json_decode($obj['data'], true);
$isFinish = true;

try{
	$decoded = JWT::decode($token, $key, array('HS256'));
	if($decoded->expire < time()){
		echo 'HET_HAN';
	}
	else{
		
		$username = $decoded->username;

		foreach ($list as $data=>$value){
			
			$id = $value['id'];
			$count = $value['count'];
			$note = $value['note'];
			$sql = "INSERT INTO ThongTinHD (idBill, idFood, count, noteOrder) values ($idBill, $id, $count, N'$note');";
			
			$stmt = sqlsrv_query( $conn, $sql);
			
			if( $stmt === false ) {
				 echo 'KHONG_THANH_CONG';
				 $isFinish = false;
				 break;
			}
		}
		
		if($isFinish){
			echo "THANH_CONG";
		}

	}
}

catch(Exception $e){
	echo 'LOI';
}
?>