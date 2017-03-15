package resources;

import static org.hamcrest.CoreMatchers.is;

import java.util.List;

import org.junit.Assert;
import org.junit.Test;

public class ReaderTest {
	private static final String ZERO =  " _ "+
		                                "| |"+
		                                "|_|";
	
	private static final String NINE =  " _ "+
									    "|_|"+
									    " _|";

	private static final String EIGHT =  " _ "+
								 	     "|_|"+
									     "|_|";
	
	private static final String SEVEN =  " _ "+
							             "  |"+
							             "  |";
							
	private static final String SIX =  " _ "+
						               "|_ "+
						               "|_|";
	
	private static final String FIVE = " _ "+
								       "|_ "+
						               " _|";
	
	private static final String FOUR = "   "+
								       "|_|"+
								       "  |";

	private static final String THREE =  " _ "+
								 	     " _|"+
									     " _|";
	
	private static final String TWO =    " _ "+
								 	     " _|"+
									     "|_ ";
	
	private static final String ONE =   "   "+
							            "  |"+
							            "  |";
	
	@Test
	public void canReadNumberZero(){
		Reader reader = new Reader();
		int result = reader.readNumber(ZERO);
		
		Assert.assertThat(result, is(0));
	}
	
	@Test
	public void canReadNumberNine(){
		Reader reader = new Reader();
		int result = reader.readNumber(NINE);
		
		Assert.assertThat(result, is(9));
	}
	
	@Test
	public void canReadNumberEight(){
		Reader reader = new Reader();
		int result = reader.readNumber(EIGHT);
		
		Assert.assertThat(result, is(8));
	}
	
	@Test
	public void canReadNumberSeven(){
		Reader reader = new Reader();
		int result = reader.readNumber(SEVEN);
		
		Assert.assertThat(result, is(7));
	}
	
	@Test
	public void canReadNumberSix(){
		Reader reader = new Reader();
		int result = reader.readNumber(SIX);
		
		Assert.assertThat(result, is(6));
	}
	
	@Test
	public void canReadNumberFive(){
		Reader reader = new Reader();
		int result = reader.readNumber(FIVE);
		
		Assert.assertThat(result, is(5));
	}
	
	@Test
	public void canReadNumberFour(){
		Reader reader = new Reader();
		int result = reader.readNumber(FOUR);
		
		Assert.assertThat(result, is(4));
	}
	
	@Test
	public void canReadNumberThree(){
		Reader reader = new Reader();
		int result = reader.readNumber(THREE);
		
		Assert.assertThat(result, is(3));
	}
	
	@Test
	public void canReadNumberTwo(){
		Reader reader = new Reader();
		int result = reader.readNumber(TWO);
		
		Assert.assertThat(result, is(2));
	}
	
	@Test
	public void canReadNumberOne(){
		Reader reader = new Reader();
		int result = reader.readNumber(ONE);
		
		Assert.assertThat(result, is(1));
	}
	
	@Test
	public void extractArrayFromString(){
		Reader reader = new Reader();
		List<String> lista = reader.extractArrayFromString("");
		
		Assert.assertThat(lista.size(), is(9));
	}
	
}
