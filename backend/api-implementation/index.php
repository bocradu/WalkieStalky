<?php
/**
 * Haufe WalkieStalky
 * @version 1.0
 */

require_once __DIR__ . '/vendor/autoload.php';
require_once 'WalkieStalkyRedisDB.php';
require_once  './lib/Models/PersonIdRecord.php';
require_once './lib/Models/PersonRecord.php';
require_once './lib/Models/ClosePersonList.php';


$app = new Slim\App();


/**
 * GET getPersonId
 * Summary: get the personId corresponding to an AuthToken. If the Person is not already in the system, a new ID is returned and the authtoken is associated with that securityDefinitions
 * Notes: 
 * Output-Formats: [application/json]
 */
$app->GET('/persons/id', function($request, $response, $args) {
                        
            $queryParams = $request->getQueryParams();
            $authtoken = $queryParams['authtoken'];    
            
	    if (empty($authtoken)) {
    			return $response->withStatus(400)->write('Bad Request - no Authtoken specified');
	    }
	    
	    $WalkieStalkyRedisDB = new WalkieStalkyRedisDB();
	    
            $userId = $WalkieStalkyRedisDB->getPersonIdByAuthtoken($authtoken);
	    
	    if (empty($userId)) {
		$userId = bin2hex(openssl_random_pseudo_bytes(32));
	        $WalkieStalkyRedisDB->setUserIdforAuthtoken($authtoken,$userId);
	    }
            
            $precord = new SwaggerServer\lib\Models\PersonIdRecord();
            $precord->personId = $userId;		          
	    
 	    $jsonResponse = json_encode($precord);	    
	    $response->write($jsonResponse);
            #$response->write('How about implementing getPersonId as a GET method ?');
            return $response;
            });


/**
 * PUT putperson
 * Summary: Put a person record into the system, along with the topics he is interested. All user posts will be automatically removed again from the system after a timespan of 5 minutes. The service responds with all users that are close to the system.
 * Notes: 
 * Output-Formats: [application/json]
 */
$app->PUT('/persons/{personid}', function($request, $response, $args) {
            
            $queryParams = $request->getQueryParams();
            $authtoken = $queryParams['authtoken'];       
	    
	    //dummy authorization

            if (empty($authtoken)) {
                return $response->withStatus(400)->write('Bad Request - no Authtoken specified');
	    }

            //parse request body		
            $parsedBody = $request->getParsedBody();
            //var_dump($parsedBody);
	    
	    $personRecord = new SwaggerServer\lib\Models\PersonRecord();
	    
            
            
            $personRecord->personId = $parsedBody["personId"];
	    $personRecord->name=$parsedBody["name"];
	    $personRecord->phonenumber=$parsedBody["phonenumber"];
	    $personRecord->topics = $parsedBody["topics"];
            $personRecord->coordinates = $parsedBody["coordinates"];

            //$dummyResponse = json_encode($personRecord);
	    //$response->write($dummyResponse);
			 
            $WalkieStalkyRedisDB = new WalkieStalkyRedisDB();
            $WalkieStalkyRedisDB->updateGeoLocation($personRecord);
            //store our new person Record in the Database
            $WalkieStalkyRedisDB->updatePersonRecord($personRecord);
            
            //getListOfPeopleThatAreClose :-D (radius 1000m)
            $closePersonIds = $WalkieStalkyRedisDB->getClosePersons($personRecord,1000);
            //var_dump($result);  
 	    //assemble close person list
	    $cpl = array();
	    
	    $matchscore=0;
	    $matchedRecord = NULL;		    
	    foreach ($closePersonIds as $cid) {
	
		$closePersonJSON = $WalkieStalkyRedisDB->getPersonRecordJSON($cid);
		$p = json_decode($closePersonJSON, true);
		$pr = null;
		$pr = new SwaggerServer\lib\Models\PersonRecord();
		$pr->personId=$p["personId"];
	        if (strcmp($pr->personId,$personRecord->personId)!=0) {	
			$pr->name=$p["name"];
			$pr->phonenumber=$p["phonenumber"];
			$pr->topics = $p["topics"];
		
			//now we see if there's a topic match
			$tempscore = 0;
			$uts = $pr->topics;
			$mts = $personRecord->topics;
			foreach ($uts as $userTopic) {
		  		foreach($mts as $myTopic) {	
				if (strcmp($myTopic,$userTopic)==0) {
					$tempscore = $tempscore+1;
				}
                  		}			
			}
			//echo $pr->name. " " . $personRecord->name." ".strval($tempscore);		
			if ($tempscore>$matchscore) {
				$matchscore=$tempscore;
				$matchedRecord=$pr;
			}	

			$pr->coordinates = $p["coordinates"];
			array_push($cpl,$pr);	
		}	
	    }
			    
	    $closePersonList = new SwaggerServer\lib\Models\ClosePersonList(); 
	    //var_dump($closePersonList);
	    $closePersonList->closePersons=$cpl;
 	    $closePersonList->match=$matchedRecord;
	    
	    $response->write(json_encode($closePersonList,JSON_PRETTY_PRINT));
            	
            });


/**
 * GET test
 * Summary: A generic development test endpoint that certainly does voodoo. It is very dangerous and may attack anytime. We must deal with it.
 * Notes: 
 * Output-Formats: [application/json]
 */
$app->GET('/test', function($request, $response, $args) {
            
            
            
        $response->write('How about implementing test as a GET method ?');
        return $response;
        });



$app->run();
