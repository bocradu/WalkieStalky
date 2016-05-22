<?php
require_once __DIR__ . '/vendor/autoload.php';
require './lib/Models/PersonRecord.php';

class WalkieStalkyRedisDB {	
	
        
		
	function getPersonIdByAuthtoken($authtoken) { 
		$redis = new Predis\Client();			
		return $redis->hget("authtokens2UserId",$authtoken);	
	}

        function setUserIdforAuthtoken($authtoken,$userId) {
		$redis = new Predis\Client();	        	
		
		return $redis->hset("authtokens2UserId",$authtoken,$userId);
        
        }


	function updateGeoLocation($personRecord) {
		$redis = new Predis\Client();
		
		$personId = $personRecord->personId;
		$longitude = floatval($personRecord->coordinates["longitude"]);
		$latitude = floatval($personRecord->coordinates["latitude"]);
		
		//first delete the old location form the location set
		try {
			$response = $redis->zrem("personLocations",$personId);
		} catch (Exception $ex) {
			
			echo "Exception" . $ex->getMessage();

		}
		//now add the 
		//$geoUpdateCommand = Predis\Command\RawCommand::create('GEOADD', 'personLocations', $longitude,$latitude);
		try {
			$result=$redis->executeRaw(['GEOADD','personLocations',$longitude,$latitude,$personId]);
		} catch (Exception $ex) {
			
			echo $ex->getMessage();

		}
        }

	function updatePersonRecord($personRecord) {
	        
                $personId = $personRecord->personId;
                		
		$jsonEntry = json_encode($personRecord);
		$redis = new Predis\Client();
		$redis->hset("personRecords",$personId,$jsonEntry);
		
	}
	
	function getPersonRecordJSON($personId) {
		$redis = new Predis\client();
		return $redis->hget("personRecords",$personId);

	}
	

	//get perons in a a certain radius around me. use $radius in meters!
	function getClosePersons($personRecord, $radius) {

                try {
                        $redis = new Predis\Client();

		} catch (Exception $ex) {
			
			echo "Exception" . $ex->getMessage();

		}

		$result = NULL;

		try {
			$result=$redis->executeRaw(['GEORADIUSBYMEMBER','personLocations',$personRecord->personId,$radius,'m']);
		} catch (Exception $ex) {
			
			echo $ex->getMessage();

		}
		
		return $result;


	}
	

}
?>
