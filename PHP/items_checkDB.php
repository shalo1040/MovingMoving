<?php
	$userID = $_POST["userID"];
	$item = $_POST["item"];
	$count = 0;

	$con = mysqli_connect("localhost", "student", "student1234", "Dodol");

	$sql = "select * FROM Items WHERE userID = '$userID'";

	$result = mysqli_query($con, $sql);
	$row = mysqli_fetch_array($result);

	if($item == "potion")
		$count = $row["potionItem"];
	else $count = $row["shieldItem"];

	if($count != 0) {
		if($item == "potion") {
			$sql2 = "update Items SET potionItem = potionItem - 1 WHERE userID = '$userID'";
			echo "true*".$row["shieldItem"]."*".($count-1);
		}
		else {
			$sql2 = "update Items SET shieldItem = shieldItem - 1 WHERE userID = '$userID'";
			echo "true*".($count-1)."*".$row["potionItem"];
		}
		mysqli_query($con, $sql2);
	}
	else echo "false";

	mysqli_close($con);
?>