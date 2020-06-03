<?php
	$userID = $_POST["userID"];

	$con = mysqli_connect("localhost", "student", "student1234", "Dodol");
	$sql = "select * FROM Marbles WHERE userID = '$userID'";

	$result = mysqli_query($con, $sql);
	while($row = mysqli_fetch_array($result)) {
		echo $row["lv1"]."*";
		echo $row["lv2"]."*";
		echo $row["lv3"]."*";
	}

	mysqli_close($con);
?>