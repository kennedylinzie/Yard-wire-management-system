<?php 
   require("conn.php");



$sql = "SELECT uu_id, username, password,coins,level FROM users";
$result = mysqli_query($conn, $sql);

if (mysqli_num_rows($result) > 0) {
  // output data of each row
  while($row = mysqli_fetch_assoc($result)) {
    echo "id: " . $row["uu_id"]. " " . $row["username"]. " " . $row["password"]. " " . $row["coins"]. " " . $row["level"]. "<br>";
  }
} else {
  echo "0 results";
}

mysqli_close($conn);



?>