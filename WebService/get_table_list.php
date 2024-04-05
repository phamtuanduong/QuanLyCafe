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
/*
class Table{

	function Table($id, $name, $status){
		$this->id = $id;
		$this->name = $name;
		$this->status = $status;
	}
}*/

class Table {
    public int $id;
    public string $name;
	public string $status;

    public function __construct(int $id, string $name, string $status) {
        $this->id = $id;
        $this->name = $name;
		$this->status = $status;
    }
}

try{
	$decoded = JWT::decode($token, $key, array('HS256'));
	if($decoded->expire < time()){
		echo 'HET_HAN';
	}
	else{
		
		$username = $decoded->username;

		$sql = "SELECT * FROM BAN";
		$stmt = sqlsrv_query( $conn, $sql);
		$result = array();
		
		while( $row = sqlsrv_fetch_array( $stmt, SQLSRV_FETCH_ASSOC) ) {
			
			  array_push($result, new Table($row['id'], $row['name'], $row['status']));
		}

		if($result){
			print_r(json_encode($result, true));
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