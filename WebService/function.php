<?php
//function
use \Firebase\JWT\JWT;
require __DIR__ . '/vendor/autoload.php';


function getToken($username, $key='tuanduong_2909'){
	$token = array(
		"username" => $username,
	    "iat" => time(),
	    "expire" =>time() + 86400*2 //2 days
	);
	return $jwt = JWT::encode($token, $key);
}

?>