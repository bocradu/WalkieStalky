<?php
require_once __DIR__ . '/vendor/autoload.php';

class WalkieStalkyRedisDB {	

	function getPersonIdByAuthtoken($authtoken) { 
		$redis = new Predis\Client();			
		return $redis->hget("usersByAuthtoken",$authtoken);	
	}

        function setUserIdforAuthtoken($authtoken,$userId) {
		$redis = new Predis\Client();	        	
		
		return $redis->hset("usersByAuthtoken",$authtoken,$userId);
        
        }







}

?>
