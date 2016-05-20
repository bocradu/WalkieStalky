<?php
/**
 * Haufe WalkieStalky
 * @version 1.0
 */

require_once __DIR__ . '/vendor/autoload.php';

$app = new Slim\App();


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



$app->run();
