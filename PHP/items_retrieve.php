<?php
	$userID = $_POST["userID"];

	$con = mysqli_connect("localhost", "student", "student1234", "Dodol");
	$sql = "select * FROM Items WHERE userID = '$userID'";

	$result = mysqli_query($con, $sql);
	while($row = mysqli_fetch_array($result)) {
		echo $row["potionItem"]."*";
		echo $row["shieldItem"]."*";
	}

	mysqli_close($con);
?>