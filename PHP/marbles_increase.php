<?php
	$userID = $_POST["userID"];
	$marble = $_POST["marble"];

	$con = mysqli_connect("localhost", "student", "student1234", "Dodol");

	if($marble == "lv1")
		$sql = "update Marbles SET lv1 = lv1 + 1 WHERE userID = '$userID'";
	else if($marble == "lv2")
		$sql = "update Marbles SET lv2 = lv2 + 1 WHERE userID = '$userID'";
	else
		$sql = "update Marbles SET lv3 = lv3 + 1 WHERE userID = '$userID'";

	mysqli_query($con, $sql);
	mysqli_close($con);
?>