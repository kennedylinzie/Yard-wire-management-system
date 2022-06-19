<?php
   require("conn.php");
   require("encryption.php");

//night notes
if($_POST['key']==1)
 {

    $Noteboday = $_POST["Noteboday"];


    $sql = "SELECT COUNT(`note_id`) FROM `limbe_shunting_plan_control_night` WHERE 1";
    $result = mysqli_query($conn, $sql);

        while($row = mysqli_fetch_assoc($result)) {


            if($row["COUNT(`note_id`)"] > 0)
            {

              $sql_for_if = "SELECT `note_id`  FROM `limbe_shunting_plan_control_night` WHERE 1";
              $result_for_if = mysqli_query($conn, $sql_for_if);

                  while($row = mysqli_fetch_assoc($result_for_if)) {

                     $pos = $row["note_id"];
                    $sql = "UPDATE limbe_shunting_plan_control_night SET	Noteboday='$Noteboday' WHERE note_id='$pos'";

                      if (mysqli_query($conn, $sql)) {
                        echo "upload Successful";
                      } else {
                        echo "upload UnSuccessful";
                      }

                 }
            }
             else if($row["COUNT(`note_id`)"] == 0)
            {
                  $sql_regi = "INSERT INTO `limbe_shunting_plan_control_night` (`note_id`, `Noteboday`, `TIME`) VALUES (null, '$Noteboday',null)";

                  if (mysqli_query($conn, $sql_regi)) {
                    echo "upload Successful";
                  } else {
                    echo "upload UnSuccessful";
                  }
            }

        }

    mysqli_close($conn);

}


//day notes
if($_POST['key']==2)
 {

    $Noteboday = $_POST["Noteboday"];


    $sql = "SELECT COUNT(`note_id`) FROM `limbe_shunting_plan_control` WHERE 1";
    $result = mysqli_query($conn, $sql);

        while($row = mysqli_fetch_assoc($result)) {


            if($row["COUNT(`note_id`)"] > 0)
            {

              $sql_for_if = "SELECT `note_id`  FROM `limbe_shunting_plan_control` WHERE 1";
              $result_for_if = mysqli_query($conn, $sql_for_if);

                  while($row = mysqli_fetch_assoc($result_for_if)) {

                     $pos = $row["note_id"];
                    $sql = "UPDATE limbe_shunting_plan_control SET	Noteboday='$Noteboday' WHERE note_id='$pos'";

                      if (mysqli_query($conn, $sql)) {
                        echo "upload Successful";
                      } else {
                        echo "upload UnSuccessful";
                      }

                 }
            }
             else if($row["COUNT(`note_id`)"] == 0)
            {
                  $sql_regi = "INSERT INTO `limbe_shunting_plan_control` (`note_id`, `Noteboday`, `TIME`) VALUES (null, '$Noteboday',null)";

                  if (mysqli_query($conn, $sql_regi)) {
                    echo "upload Successful";
                  } else {
                    echo "upload UnSuccessful";
                  }
            }

        }

    mysqli_close($conn);

}


//get day data
if($_POST['key']==3)
 {

    $sql = "SELECT Noteboday FROM limbe_shunting_plan_control";
    $result = mysqli_query($conn, $sql);

    if (mysqli_num_rows($result) > 0) {
      // output data of each row

          while($row = mysqli_fetch_assoc($result)) {

          echo $row["Noteboday"];
          }

    } else {
    //  echo "0 results";
}

mysqli_close($conn);

}
//get night data
if($_POST['key']==4)
 {

    $sql = "SELECT Noteboday FROM limbe_shunting_plan_control_night";
    $result = mysqli_query($conn, $sql);

    if (mysqli_num_rows($result) > 0) {
      // output data of each row

          while($row = mysqli_fetch_assoc($result)) {

          echo $row["Noteboday"];
          }

    } else {
    //  echo "0 results";
}

mysqli_close($conn);

}

?>
