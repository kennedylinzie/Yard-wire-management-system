<?php
$servername = "localhost";
$username = "root";
$password = "";
$db_name = "railsystem";

// Create connection
$conn = mysqli_connect($servername, $username, $password,$db_name);

// Check connection
if (!$conn) {
    echo "Something went wrong";
  die("Connection failed: " . mysqli_connect_error());

}
//echo "Connected successfully";
?>
