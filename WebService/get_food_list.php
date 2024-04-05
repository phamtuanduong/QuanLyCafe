<?php
use \Firebase\JWT\JWT;
require __DIR__ . '/vendor/autoload.php';
include('function.php');
include('connect/connect.php');

$key = "tuanduong_2909";

$json = file_get_contents('php://input');
$obj = json_decode($json, true);
$token = $obj['token'];

//$token = $_GET['token'];

class Food{
	
	public int $id;
	public string $name;
	public int $idCategory;
	public float $price;
	
	
	function __construct($id, $name, $idCategory, $price){
		$this->id = $id;
		$this->name = $name;
		$this->idCategory = $idCategory;
		$this->price = $price;
	}
}

try{
	$decoded = JWT::decode($token, $key, array('HS256'));
	if($decoded->expire < time()){
		echo 'HET_HAN';
	}
	else{
		
		$username = $decoded->username;
		
		$sql = "SELECT * FROM THUCAN";
		$stmt = sqlsrv_query( $conn, $sql);
		$result = array();
		
		while( $row = sqlsrv_fetch_array( $stmt, SQLSRV_FETCH_ASSOC) ) {
			
			  array_push($result, new Food($row['id'], $row['name'], $row['idCategory'], $row['price']));
		}
		
		
		if($result){
			print_r(json_encode($result));
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