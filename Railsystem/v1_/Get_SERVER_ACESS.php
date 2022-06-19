<?php
   require("conn.php");


      $sql = "SELECT CURRENT_USER() limit 1";
      $result = mysqli_query($conn, $sql);

      if (mysqli_num_rows($result) > 0) {
        // output data of each row

            while($row = mysqli_fetch_assoc($result)) {

          echo $row["CURRENT_USER()"];
            }

      } else {
        echo "Unsuccessfull";
      }

      mysqli_close($conn);
