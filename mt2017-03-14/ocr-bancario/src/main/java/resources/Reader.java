package resources;

import java.util.Arrays;
import java.util.List;

public class Reader {
	public int readNumber(String number){
		List<String> asList = Arrays.asList(number.split(""));
		
		long pipes = asList.stream().filter(x -> x.equals("|")).count();
		long underscores = asList.stream().filter(x -> x.equals("_")).count();
		
		if(pipes == 3 && underscores == 3 && number.charAt(5) != ' ')
			return 9;
		
		if(pipes == 4 && underscores == 3)
			return 8;
		
		if(pipes == 2 && underscores == 1)
			return 7;
		
		if(pipes == 3 && underscores == 3 && number.charAt(5) == ' ')
			return 6;
		
		if(pipes == 2 && underscores == 3 && number.charAt(5) == ' ')
			return 5;
		
		if(pipes == 3 && underscores == 1)
			return 4;
		
		if(pipes == 2 && underscores == 3 && number.charAt(6) == ' ')
			return 3;
		
		if(pipes == 2 && underscores == 3)
			return 2;
		
		if(pipes == 2 && underscores == 0)
			return 1;
		
		return 0;
	}
	
	public List<String> extractArrayFromString(String number){
		return Arrays.asList("","","","","","","","","");
	}
}
