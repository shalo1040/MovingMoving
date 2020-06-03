<?php
	$userID = $_POST["userID"];

	$con = mysqli_connect("localhost", "student", "student1234", "Dodol");

	$sql = "select * FROM Monsters WHERE userID = '$userID'";

	$result = mysqli_query($con, $sql);
	$row = mysqli_fetch_row($result);
	for($i=1; $i<13; $i++)
		echo $row[$i]."*";

	mysqli_close($con);
?>