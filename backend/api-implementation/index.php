<?php
/**
 * Haufe WalkieStalky
 * @version 1.0
 */

require_once __DIR__ . '/vendor/autoload.php';
require 'WalkieStalkyRedisDB.php';
require './lib/Models/PersonIdRecord.php';

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
	    		   	    
	         
            $body = $request->getParsedBody();
            $response->write('How about implementing putperson as a PUT method ?');
            return $response;
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
