<?php
/*
 * PersonRecord
 */
namespace SwaggerServer\lib\Models;

/*
 * PersonRecord
 */
class PersonRecord {
    /* @var string $personId A public technical id we can use to connect to the user */
    public $personId;
    /* @var string $name The name to display on other people&#39;s phones */
    public $name;
    /* @var string $phonenumber The phone number of the user */
    public $phonenumber;
    /* @var string[] $topics  */
    public $topics;
    /* @var \SwaggerServer\lib\Models\GeoCoordinates $coordinates  */
    public $coordinates;
    

    public function setJSONData($data) {
        foreach ($data AS $key => $value) $this->{$key} = $value;
    }

}
