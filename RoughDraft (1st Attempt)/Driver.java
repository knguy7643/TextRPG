import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JPanel;
import javax.swing.JScrollBar;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;
import javax.swing.event.CaretEvent;
import javax.swing.event.CaretListener;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.AdjustmentEvent;
import java.awt.event.AdjustmentListener;
import java.awt.event.ComponentEvent;
import java.awt.event.ComponentListener;

public class Driver {
	
	private static Player player = new Player();
	private static String name = "";
	private static String offset = "\n\n";
	private static CharacterClass cClass = CharacterClass.NONE;
	private static JPanel JPanel;
	private static Floor initial = new Floor(0);

	public static void main(String[] args) {
		
		//Initialize GUI
		JFrame frame = new JFrame("Aetheria - A Simple Text RPG");
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setResizable(false);
		frame.setSize(700, 400);
		
		//Formation of Menu Bar
		JMenuBar menuBar = new JMenuBar();
		JMenu file = new JMenu("File");
		JMenu setting = new JMenu("Settings");
		
		menuBar.add(file);
		menuBar.add(setting);
		
		//Generate Save File 
		JMenu saveButton = new JMenu("Save as...");
		file.add(saveButton);
		
		JMenuItem file1 = new JMenuItem("Save File 1");
		JMenuItem file2 = new JMenuItem("Save File 2");
		JMenuItem file3 = new JMenuItem("Save File 3");
		
		saveButton.add(file1);
		saveButton.add(file2);
		saveButton.add(file3);
		
		//Initialize TextArea and ScrollPane where the text will be printed to. //TODO Figfure out how to get JScroll to scroll.
		JTextArea system = new JTextArea();
		system.setEditable(false);
		system.setLineWrap(true);
		system.setWrapStyleWord(true);
		
		JScrollPane vertical = new JScrollPane(system);

		vertical.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_ALWAYS);
		
		//Enables Auto-Scroll
		system.setCaretPosition(system.getDocument().getLength());
		
		//Initialize TextBox panel for player to enter Character name.
		JPanel textP = new JPanel();
		JLabel text = new JLabel("Enter Text:");
		JTextField textField = new JTextField(20);
		JButton send = new JButton("Send");
		JButton reset = new JButton("Reset");
		
		textP.add(text);
		textP.add(textField);
		textP.add(send);
		textP.add(reset);
		
		//Initialize Start Panel with option for new game or resume saved game. 
		JPanel fileChoice = new JPanel();
		
		JButton newFile = new JButton("New Game");
		JButton savedFile = new JButton("Saved File");
		
		fileChoice.add(newFile);
		fileChoice.add(savedFile);
		
		//Initialize Saved File Choices
		JPanel savedFiles = new JPanel();
		
		JButton savedFile1 = new JButton("Saved File 1");
		JButton savedFile2 = new JButton("Saved File 2");
		JButton savedFile3 = new JButton("Saved File 3");
		JButton back = new JButton("Back");
		
		savedFiles.add(savedFile1);
		savedFiles.add(savedFile2);
		savedFiles.add(savedFile3);
		savedFiles.add(back);
		
		//Initialize a panel to display player information. 
		JPanel playerDisplay = new JPanel();
		JLabel playerName = new JLabel("Name: " + player.getName());
		JLabel playerClass = new JLabel("Class: " + player.getStringClass());
		JLabel playerLevel = new JLabel("Lvl: " + player.getLevel());
		JLabel playerExp = new JLabel("Exp: " + player.getTotalExp());
		JLabel playerHP = new JLabel("HP: " + player.getCurrentHP() + "/" + player.getMaxHP());
		JLabel playerATK = new JLabel("Attack: " + player.getAtk());
		JLabel playerDEF = new JLabel("Defense: " + player.getDef());
		
		playerDisplay.setLayout(new GridLayout(7, 1));
		
		playerDisplay.add(playerName);
		playerDisplay.add(playerClass);
		playerDisplay.add(playerLevel);
		playerDisplay.add(playerExp);
		playerDisplay.add(playerHP);
		playerDisplay.add(playerATK);
		playerDisplay.add(playerDEF);
		
		//Initialize a panel to hear the story.
		JPanel choice = new JPanel();
		JButton yes = new JButton("YES");
		JButton no = new JButton("NO");
		
		choice.add(yes);
		choice.add(no);
		
		//Initiate Continue Button
		JPanel continuePanel = new JPanel();
		JButton continueButton = new JButton("CONTINUE");
		
		continuePanel.add(continueButton);
		
		//Initialize a panel for Character Class options.
		JPanel classChoice = new JPanel();
		JButton swordsman = new JButton("Swordsman");
		JButton mage = new JButton("Mage (NOT IMPLEMENTED YET");
		JButton archer = new JButton("Archer");
		
		classChoice.add(swordsman);
		classChoice.add(archer);
		//classChoice.add(mage); Not ready to add yet.
		
		//Add items to the frame.
		frame.getContentPane().add(BorderLayout.NORTH, menuBar);
		frame.getContentPane().add(BorderLayout.WEST, playerDisplay);
		frame.getContentPane().add(BorderLayout.SOUTH, fileChoice);
		frame.getContentPane().add(BorderLayout.CENTER, vertical);
		
		frame.setVisible(true);
		
		//Outprint initial message for players.
		system.append("Welcome to Aetheria. Challenge the tower and receive the power of the gods! Would you like to start a new file or resume a saved file?" + offset);
		
		//ActionListener for New File
		newFile.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				frame.getContentPane().remove(fileChoice);
				frame.getContentPane().add(BorderLayout.SOUTH, textP);
				
				frame.revalidate();
				
				system.append("Your eyes awaken to the bright blue sky staring down upon you as the gentle ocean breeze nudges against your skin. As you stare off the edge of the boat, you see the Kingdom of Fiore come into view. Upon "
						+ "disembarking the ship, you find youself in the port city of Elodas. Having spent the last 14 years of youe life as an orphan on the small island nation of Capylas, you decided to leave the island and explore the "
						+ "world. The first thing to catch your attention is the large tower shaped object as it never-endingly streches into the deep blue sky. You don't give it much thought and decide to find youself a "
						+ "motel for the night before deciding what to do next. Later that night while enjoying youself a meal at a nearby bar, a middle-aged man who seems to be a local fisherman, introduces himself to as \"Joseph Pisca\" "
						+ "and asks if the empty seat next to you was taken. You introduced youself as ... and nodded your head as if you were saying \"Nah, go right ahead\"." + offset);
				
				system.append("Please type the desired character name below." + offset);
				
			}
		}));
		
		//ActionListener for Send and Reset JButtons.
		send.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				name = textField.getText();
				
				frame.getContentPane().remove(textP);
				frame.getContentPane().add(BorderLayout.SOUTH, classChoice);
				
				frame.revalidate();
				
				system.append("Player Name has been set to " + name + "." + offset);
				
				frame.revalidate();
				
				system.append("Jospeh orders a beer from the bar and proceeds to ask you \"Another new face huh?\"" + offset);
				
				system.append("Please choose a class. The Swordsman Class specializes in increased health values. The Archer Class specializes in increased attack values. The Mage Class is currently unvailable."
						+ " Classes cannot be changed moving foward." + offset);
				
			}
		}));
		
		reset.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				textField.setText("");
				
			}
		}));
		
		//ActionListener to Load A Save File
		savedFile.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {

				frame.getContentPane().remove(fileChoice);
				frame.getContentPane().add(BorderLayout.SOUTH, savedFiles);
				
				frame.revalidate();
				
			}
		}));
		
		//ActionListener to load saveFile 1
		savedFile1.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				String filename = "savefile1";
				try {
					player = loadFile(filename);
				} catch (NumberFormatException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				} catch (IOException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		}));
		
		//ActionListener to load saveFile 2
		savedFile2.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				String filename = "savefile2";
				try {
					player = loadFile(filename);
				} catch (NumberFormatException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				} catch (IOException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		}));
		
		//ActionListener to load saveFile 3
		savedFile3.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				String filename = "savefile3";
				try {
					player = loadFile(filename);
				} catch (NumberFormatException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				} catch (IOException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		}));
		
		back.addActionListener((new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				frame.getContentPane().remove(savedFiles);
				
				frame.getContentPane().add(BorderLayout.SOUTH, fileChoice);
				
				frame.revalidate();
			}
			
		}));
		
		//ActionListener for Character Class Choices
		swordsman.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				cClass = CharacterClass.SWORDSMAN;
				
				frame.getContentPane().remove(classChoice);
				frame.getContentPane().add(BorderLayout.SOUTH, choice);
				
				frame.revalidate();
				
				system.append("You introduce youself to Joseph as " + name + ", a " + cClass.toString() + "." + offset);
				
				system.append("\"You must be here to challenge the tower,\" Joseph says. You respond with \"The tower you ask?\" (It must have been that thing stretching into the sky you"
						+ " think to youself.) \"OH?!? You don't know about the tower? Would you like to hear about it?\" Joesph replies." + offset);

				
			}
		}));
		archer.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				cClass = CharacterClass.ARCHER;
				
				frame.getContentPane().remove(classChoice);
				frame.getContentPane().add(BorderLayout.SOUTH, choice);
				
				frame.revalidate();
				
				system.append("You introduce youself to Joseph as " + name + ", a " + cClass.toString() + "." + offset);
				
				system.append("\"You must be here to challenge the tower,\" Joseph says. You respond with \"The tower you ask?\" (It must have been that thing stretching into the sky you"
						+ " think to youself.) \"OH?!? You don't know about the tower? Would you like to hear about it?\" Joesph replies." + offset);
				
			}
		}));
		mage.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				cClass = CharacterClass.MAGE;
				
				frame.getContentPane().remove(classChoice);
				frame.getContentPane().add(BorderLayout.SOUTH, choice);
				
				frame.revalidate();
				
				system.append("You introduce youself to Joseph as " + name + ", a " + cClass.toString() + "." + offset);
				
				system.append("\"You must be here to challenge the tower,\" Joseph says. You respond with \"The tower you ask?\" (It must have been that thing stretching into the sky you"
						+ " think to youself.) \"OH?!? You don't know about the tower? Would you like to hear about it?\" Joesph replies." + offset);
				
			}
		}));
		
		//ActionListener to play Story.
		yes.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				frame.getContentPane().remove(choice);
				
				frame.getContentPane().add(BorderLayout.SOUTH, continuePanel);
				
				frame.revalidate();
				
				playStory(system);
				
				frame.revalidate();
				
				continueButton.addActionListener(new ActionListener() {

					@Override
					public void actionPerformed(ActionEvent e) {
						beginTutorial(system);
						
						frame.getContentPane().remove(continuePanel);
						
						frame.revalidate();
						
					}
					
				});
				
			}
		}));
		no.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				frame.getContentPane().remove(choice);
				
				frame.revalidate();
			
				system.append("Welcome to the Tower! I am Capution, the Tower's gatekeeper. Before you can begin climbing the tower, you must pass my Trial. Let's hope you are ready." + offset +
				"(PRESS THE CONTINUE BUTTON TO CONTINUE)" + offset);
				
				beginTutorial(system);
				
				frame.revalidate();
				
			}
		}));

	}
	
	public static void beginTutorial(JTextArea system) {
		
		system.append("This is the Oth Floor, a place where those chosen by the tower can begin their ascent. You...You were not chosen by the Tower, but you were able to open its doors. That means you are what the "
				+ "residents of the Tower call an Irregular. That aside, my role is to simply ensure that those who wish to challenge the Tower are qualified to do so. The tower is created by divine mana "
				+ "called shinsu.");
		
		player = new Player(name, cClass);
		
		JPanel actionChoice = new JPanel();
		JButton 
		
		
		
	}
	
	public static void playStory(JTextArea system) {
		
		system.append("Jospeh begins to narrarate. \"Long ago, this world was created by one singular celestial being who granted oversight of this world to 9 of his progeny. To mere humans like us, they were practically gods. "
				+ "One day, they grew tired of sharing and soon a war broke out between them. The youngest was Tet, the God of Games. Unlike his siblings who never meddled in the affairs of the mortal realm, Tet frequently traveld from human cities to"
				+ " to elven forest to dwarven mountains. Tet travelled the mortal realm seeking new games. He didn't want to be a god, all he wanted was play new games. But as the war raged on, Tet was the only one "
				+ "to never picked a side. With both sides evenly matched and multiple failed attempts to recruit Tet, the other 8 gods ended up bringing each other's demise. With their perishing, the war was over, and"
				+ " and Tet was the sole god of this world. But since he didn't want this responsibility, he created the tower so that he could find one worthy of being this worlds god.\""
				+ offset);
		
		system.append("\"So how much do we know about the tower?\" You ask." + offset);
		
		system.append("\"Well, the tower is very intricate in nature. Tet constructed it as if he were building a game."
				+ " I'm just a fisherman, so I don't know to much about it. But if you are interested in climbing the tower, you should visit it and talk to the gatekeeper.\"" + offset);
		
		system.append("The following day, you pack up and decided to the head to the tower. After a week of travel, you reach the gate to the tower. The doors sense your presence and opens up to a dark corrider with practically no light."
				+ " As you walk into the darkness with little to no fear, you hear the doors slam shut behind you and blue flame pillar light up the room. Before you stands the Tower's gatekeeper." + offset);
	
	}
	
	public static void saveFile(String filename, Player player, Floor floor) throws IOException {
		
		BufferedWriter writer = new BufferedWriter(new FileWriter(filename));

		writer.write(player.getSaveData() + "\n" + floor.getFloorNum());
		
		writer.close();
		
	}
	
	public static Player loadFile(String filename) throws NumberFormatException, IOException {

		BufferedReader reader = new BufferedReader(new FileReader(filename));
		
		String name = reader.readLine();
		
		String typeString = reader.readLine();
		
		CharacterClass characterClass = null;
		
		if (typeString.equals("SWORDMAN")) {
			characterClass = CharacterClass.SWORDSMAN;
		}
		else if (typeString.equals("MAGE")) {
			characterClass = CharacterClass.MAGE;
		}
		else {
			characterClass = CharacterClass.ARCHER;
		}
		
		int totalExp = Integer.parseInt(reader.readLine());
		
		int level = Integer.parseInt(reader.readLine());
		
		int curHP = Integer.parseInt(reader.readLine());
		
		int floorNum = Integer.parseInt(reader.readLine());
		
		reader.close();
		
		Player temp = new Player(name, characterClass, level, totalExp, curHP);
		
		initial = new Floor(floorNum);
		
		return temp;
		
	}
	
}
