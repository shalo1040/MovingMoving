<?php
	$userID = $_POST["userID"];
	$item = $_POST["item"];

	$con = mysqli_connect("localhost", "student", "student1234", "Dodol");

	if($item == "potion")
		$sql = "update Items SET potionItem = potionItem + 1 WHERE userID = '$userID'";
	else
		$sql = "update Items SET shieldItem = shieldItem + 1 WHERE userID = '$userID'";

	mysqli_query($con, $sql);
	mysqli_close($con);
?>