<?php
date_default_timezone_set("Asia/Ho_Chi_Minh");

$serverName = "."; 
$uid = "sa";   
$pwd = "123456";  
$databaseName = "DB_CafeManagement"; 

$connectionInfo = array( "Database"=>$databaseName,"UID"=>$uid,                            
                         "PWD"=>$pwd,                            
                         "CharacterSet" => "UTF-8"); 

/* Connect using SQL Server Authentication. */  
$conn = sqlsrv_connect( $serverName, $connectionInfo);  
/*
if( $conn ) {
     echo "Connection established.<br />";
}else{
     echo "Connection could not be established.<br />";
     die( print_r( sqlsrv_errors(), true));
}*/

?>