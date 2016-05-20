<?php
/*
 * PersonRecord
 */
namespace SwaggerServer\lib\Models;

/*
 * PersonRecord
 */
class PersonRecord {
    /* @var string $publicId A public technical id we can use to connect to the user */
    private $publicId;
    /* @var string $name The name to display on other people&#39;s phones */
    private $name;
    /* @var string $phonenumber The phone number of the user */
    private $phonenumber;
    /* @var string[] $topics  */
    private $topics;
    /* @var \SwaggerServer\lib\Models\GeoCoordinates $coordinates  */
    private $coordinates;
    
}
