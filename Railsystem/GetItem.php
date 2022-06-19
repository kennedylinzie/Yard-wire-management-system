<?php
   require("conn.php");

   //$loginUser =$_POST["loginUser"];
  // $loginPass =$_POST["loginPass"];
$itemID =$_POST["itemID"];


$sql = "SELECT name,description,price FROM items WHERE ID='".$itemID."'";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
  // output data of each row
  $row = array();
      while($row = mysqli_fetch_assoc($result)) {

      $rows[] = $row;
      }
  echo json_encode($rows);
} else {
  echo "0 results";
}

mysqli_close($conn);





?>
