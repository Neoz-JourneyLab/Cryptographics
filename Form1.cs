using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Application = System.Windows.Forms.Application;

namespace UniversalEncryptor {
	public partial class Form1 : Form {
		OpenFileDialog dialog = new OpenFileDialog();
		private static readonly HttpClient client = new HttpClient();
		readonly string url = "https://pastebin.com/api/api_post.php";
		readonly User user = new();
		string rawData = "";
		byte[] rawIV = new byte[0];
		List<Word> words = new List<Word>();
		private readonly RandomNumberGenerator csp = RandomNumberGenerator.Create();

		#region Class
		class Word {
			public string value = "";
			public byte bin = 0;
		}
		class User {
			public string user_key = "";
			public string api_key = "";
		}
		#endregion

		public Form1() {
			InitializeComponent();
			button2_Click(this, null);
			button4_Click(this, null);

			Console.WriteLine(Encoding.UTF8.GetBytes(@"Ø   \u0006   X       ßï\u0005 \u0011¡“¶6   6   ö\u001bºõFßÈ!X•\bl\b E  (ð\u0013@ €\u0006Ú À¨`J\u0017Hø`ÕÛ\u0001»p/\u0018¨[ášßP\u0014  (\u0006    X   \u0006   X       ßï\u0005 D¡“¶6   6   ö\u001bºõFßÈ!X•\bl\b E  (ð\u0014@ €\u0006Ú\u001fÀ¨`J\u0017Hø`ÕÙ\u0001»'\r\n\u001dV\u007f…\\QP\u0014  ‡f    X   \u0006   X       ßï\u0005 D¡“¶6   6   ö\u001bºõFßÈ!X•\bl\b E  (ð\u0015@ €\u0006Ú\u001eÀ¨`J\u0017Hø`ÕÖ\u0001»ß\u000f,8×U\r\n\u008fP\u0014  ºv    X   \u0006   X       ßï\u0005 M¡“¶6   6   ö\u001bºõFßÈ!X•\bl\b E  (ð\u0016@ €\u0006Ú\u001dÀ¨`J\u0017Hø`ÕØ\u0001»Èo;Ò4GàUP\u0014  ŽÂ    X   \u0006   X       ßï\u0005 ¸ß“¶6   6   ö\u001bºõFßÈ!X•\bl\b E  (ð\u0017@ €\u0006Ú\u001cÀ¨`J\u0017Hø`ÕÜ\u0001»â\u000eR0ÿà+·P\u0014  GÆ    X   \u0006   X       ßï\u0005 \u0019J—¶6   6   ö\u001bºõFßÈ!X•\bl\b E  (‘\t@ €\u0006tÉÀ¨`J\u0017×¼3ØA PLÙ(¹P\u0003ó\u0005P\u0011\u0002 '©    X   \u0006   X       ßï\u0005 ë0˜¶6   6   È!X•\blö\u001bºõFß\b E( (g\u009d@ ý\u0006!"));

			//create user directory and load user pastebin credentials
			if (!Directory.Exists("user")) {
				Directory.CreateDirectory("user");
			}

			if (File.Exists("user/user_infos.json")) {
				try {
					string userInfos = File.ReadAllText("user/user_infos.json");
					user = JsonConvert.DeserializeObject<User>(userInfos)!;
				} catch (Exception ex) {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Impossible de travailler en ligne : " + ex.Message);
					Console.ForegroundColor = ConsoleColor.White;
				}
			}
			CheckPasteToken();

			CreateWordsList();

			MainPanel.Visible = false;

			if (!File.Exists($"user/key.key")) {
				panel1Register.Visible = true;
				panel2Auth.Visible = false;
			} else {
				panel1Register.Visible = false;
				panel2Auth.Visible = true;
			}
		}

		void CreateWordsList() {
			byte n = 0;
			string wordList;
			wordList = "able\nabout\nagain\nair\nall\nalways\nand\nanswer\nany\naround\nas\nask\nat\nback\nbe\nbefore\nbest\nbetter\nbetween\nblack\nbody\nbook\nboy\nbrother\nbut\ncall\ncan\ncar\ncareful\ncat\nchair\nchance\ncheese\nchild\ncinema\nclean\nclear\nclose\ncold\ncome\ncould\ncountry\ncry\ncut\ndance\ndaughter\nday\ndinner\ndo\ndoctor\ndocument\ndog\ndoor\ndown\ndream\ndrink\neach\neasy\neat\negg\neight\nend\neverything\nexplain\neye\nface\nfamily\nfather\nfind\nfire\nfirst\nfor\nfriend\nfrom\ngame\nget\ngirl\ngive\ngo\ngood\nhand\nhe\nhead\nhelp\nher\nhis\nhome\nidea\nif\nimportant\nin\ninformation\ninside\ninteresting\nit\njob\nkind\nknow\nland\nlearn\nlife\nlight\nlive\nlong\nmake\nman\nmany\nmay\nmoney\nmore\nmorning\nmove\nmy\nname\nnew\nno\nnow\noften\none\nopen\nor\nout\npage\npaper\npark\npay\npeace\npen\npeople\nperson\npicture\nplace\nplay\nplease\npopular\nprefer\nproblem\nput\nquestion\nreach\nread\nready\nred\nrest\nrich\nright\nriver\nroad\nroom\nrun\nsame\nsay\nschool\nsecond\nsee\nsend\nset\nshe\nship\nshop\nshould\nshow\nsit\nsmall\nso\nsome\nson\nsoon\nspeak\nstand\nstart\nstone\nstop\nstudent\nsuch\ntable\nthat\nthe\nthere\nthey\nthing\nthink\nthis\ntime\ntoday\ntwo\nunderstand\nup\nvery\nvisit\nwait\nwant\nwe\nwhat\nwhere\nwhy\nword\nwork\nwrite\nyou\nacross\naction\nafter\nagainst\nage\nalmost\nalone\nalready\nalso\nanything\narmy\nart\naway\nbad\nbeautiful\nbecause\nbecome\nbed\nbig\nbox\nbread\nbreakfast\nbring\nbus\nbuy\ncamera\ncare\ncarry\ncatch\ncause\ncertain\nchange\nchief\nchurch\ncity\nclass\ncompany\nconfirm\ncontinue\ncontrol\ncorner\ncost\ncover\nculture\ndead\ndear\ndecision\ndeep\ndescribe\ndesert\ndie\ndifficult\ndistance\ndress\ndrive\ndry\neast\neducation\nenjoy\nenough\nevening\nevery\nexample\nexpect\nexpensive\nfact\nfast\nfeel\nfew\nfight\nflower\nfood\nfree\nfull\ngarage\ngarden\ngold\ngreat\ngreen\ngroup\nhappy\nhard\nhave\nhere\nhope\nhouse\nhow\nill\nimpossible\ninclude\nindustry\ninterest\ninto\ninvite\nisland\njourney\njuice\nkeep\nlate\nleave\nlet\nletter\nlike\nlook\nmeet\nmember\nmiss\nmoment\nmonth\nmost\nmother\nmuch\nmust\nneed\nnever\nnext\nnothing\nold\non\nonly\nother\nown\npart\npersonal\nphone\nplan\nplayer\npolice\nposition\npossible\npower\npresent\npresident\npretty\nprice\nproduct\nprovide\npublic\nquite\nrather\nreal\nreason\nreceive\nrecord\nremain\nremember\nreport\nresult\nreturn\nround\nsad\nsave\nsea\nseat\nservice\nseveral\nshall\nside\nsingle\nsister\nsleep\nsomething\nsorry\nsound\nsouth\nspring\nstar\nstay\nstory\nstreet\nstrong\nstudy\nsun\nsweet\nsystem\ntake\ntalk\nteacher\ntell\ntheir\nthen\nthrough\ntogether\ntoo\ntrue\ntry\nunder\nuse\nview\nvoice\nwater\nway\nweek\nwhich\nwho\nwife\nwith\nwoman\nworld\nyes\nabove\naccident\nact\nadd\naddress\nago\nairport\nalong\namong\nanother\nappear\napple\narm\nbaby\nbear\nbegin\nbehind\nbelieve\nblood\nblue\nboth\nbreak\nbuilding\nbuilt\nbusiness\ncard\ncase\ncentral\ncentury\ncheck\nchicken\nchoose\nclock\ncollect\ncolour\ncommon\ncomputer\ncondition\nconsider\ncourse\ncourt\ncrazy\ncross\ncup\ndangerous\ndark\ndecide\ndepend\ndesk\ndifferent\ndirect\ndirection\ndiscuss\ndollar\ndraw\nduring\near\nearly\nearth\nedge\neffect\neven\never\nexamine\nexchange\nfall\nfield\nfilm\nfine\nfish\nfloor\nfly\nform\nfruit\ngeneral\ngift\nglad\nglass\ngovernment\ngrow\nhalf\nhappen\nhear\nheart\nhigh\nhold\nhour\nice\nillness\nimagine\nimmediately\nincrease\ninform\ninsect\nintroduce\njump\njust\nkey\nless\nline\nlittle\nlove\nlow\nmagazine\nmark\nmaterial\nmean\nmeat\nmeeting\nmilk\nmind\nminute\nnature\nnear\nnot\nnumber\noff\noffice\nonce\norder\nover\nparent\nparty\npass\npast\npatient\npencil\nperhaps\npiece\npink\nplate\npoor\npost\nproduce\nprotect\npull\npurpose\nquick\nrace\nradio\nrain\nreally\nremove\nreply\nrespect\nride\nring\nrise\nrock\nsearch\nsecret\nsell\nsense\nsharp\nshoe\nshort\nsimilar\nsimple\nsince\nsituation\nslow\nsmile\nsnow\nsometimes\nsong\nspeed\nsport\nstate\nstation\nstill\nsuccess\nsugar\nsummer\nsure\ntall\ntea\ntelevision\ntest\nthan\nthough\nticket\ntown\ntravel\ntree\nturn\nupon\nusual\nvalley\nvalue\nvirus\nwalk\nwar\nwatch\nwell\nwhen\nwhile\nwill\nwindow\nwould\nyour\naccept\naccount\nactor\nadvance\nadvantage\nafternoon\nagree\namount\nangry\narrange\narticle\nattack\navailable\nbag\nbank\nbelow\nbird\nboat\nborrow\nbottle\nbridge\nbrown\nbuild\nbusy\nbutter\ncake\ncaptain\ncentre\ncheap\nchocolate\nchoice\ncigarette\ncloth\ncloud\nclub\ncoast\ncoat\ncoffee\ncollege\ncomfortable\ncottage\ncream\ncrowd\ncustomer\ndamage\ndate\ndeal\ndegree\ndemand\ndepartment\ndesign\ndestroy\ndetail\ndirty\ndust\nearn\nenemy\nengine\nenter\nescape\nespecially\neverywhere\nexcept\nexercise\nexpression\nfactory\nfamous\nfarm\nfavourite\nfinger\nfinish\nfollow\nfront\nfuture\ngas\ngate\ngentle\ngentleman\nground\nguide\nhair\nhat\nhistory\nholiday\nhospital\nhotel\nhungry\nillegal\nimage\nimprove\nindependent\nindividual\ninjure\ninstrument\ninterview\njoke\nkitchen\nknife\nlanguage\nlarge\nlaw\nleft\nlesson\nlisten\nmachine\nmap\nmarket\nmarry\nmeal\nmessage\nmistake\nmoon\nmusic\nnewspaper\nnice\nnight\nnose\nobject\nobtain\nocean\noil\norange\npain\npaint\nparcel\npath\npeaceful\nperfect\npetrol\nplane\nplant\npleasure\npractise\nprepare\nprison\nprivate\nprobably\nproud\nquiet\nrecently\nrefuse\nrelationship\nreligion\nrepair\nrepeat\nreplace\nrequest\nresponsible\nrestaurant\nrice\nsalt\nscience\nseason\nseem\nserious\nserve\nshape\nshoulder\nsick\nsilver\nsize\nskirt\nsky\nsmart\nsmoke\nsociety\nspecial\nspend\nsquare\nstep\nstore\nstrange\nsubject\nsuccessful\nsupply\nswim\ntaste\nteach\ntemperature\nthank\ntired\ntomorrow\ntop\ntouch\ntrain\ntrip\nuncle\nuniversity\nusually\nvegetable\nvillage\nwall\nwarm\nwash\nweather\nwelcome\nwin\nwinter\nwrong\nyesterday\nadmire\nadmit\nadventure\nafraid\nallow\nalthough\nanimal\narea\narrive\nasleep\nattempt\nattend\nattitude\naverage\nbath\nbattle\nbeer\nbelong\nbill\nboard\nborn\nbottom\nbranch\nbrave\nbreathe\ncalm\ncareless\ncertainly\nchain\ncharacter\ncharge\ncircle\nclimb\nclothes\ncoal\ncoin\ncomfort\ncomplete\nconsist\ncontain\ncook\ncopy\ncorrect\ncount\ncrime\ndeath\ndeclare\ndefend\ndelay\ndiscover\ndish\ndivide\ndouble\ndoubt\ndrop\nduty\neffort\neither\nEnglish\nequal\nevent\nexact\nexperience\nexpress\nfail\nfarmer\nfat\nflat\nfoot\nforeign\nforget\nfresh\nfunny\ngoal\ngrey\nguard\nguess\nguest\ngun\nhate\nhealth\nheavy\nhide\nhole\nhorse\nhot\nhusband\nimport\nindeed\ninfluence\ninstead\nintelligent\ninternational\niron\njacket\njoin\nkill\nlake\nlast\nlaugh\nleader\nleg\nlie\nlose\nmain\nmarriage\nmatch\nmeasure\nmedicine\nmetal\nmiddle\nmine\nmodern\nmountain\nnecessary\nnervous\nnoise\noffer\noperation\nopinion\nopposite\noutside\npair\npassenger\nperform\npile\npity\nplain\npleasant\nplenty\npoint\npolitics\npound\npour\npress\nprize\nprofit\npromise\nprove\nraise\nrecent\nreduce\nregard\nregular\nrisk\nroll\nrough\nrow\nrule\nrush\nsafe\nscore\nsecretary\nseries\nshare\nshoot\nshut\nsign\nsing\nsmell\nsmooth\nsoft\nsoldier\nsomewhere\nspace\nspeech\nspoil\nspot\nspread\nsteal\nstraight\nsuddenly\nsuggest\nsuit\nsupport\nsurface\nthese\nthick\nthin\nthird\nthose\ntoilet\ntrade\ntrouble\ntrust\ntype\nuntil\nuseful\nvariety\nvarious\nvote\nwest\nwhose\nwild\nwish\nwithout\nwonderful\nwood\nyear\nyoung";
			List<string> wds = wordList.Split('\n').ToList();
			if (!Directory.Exists("data")) {
				Directory.CreateDirectory("data");
			}
			for (int i = 0; i < 256; i++) {
				Word w = new Word() {
					value = wds[(int)((i / 256f) * wds.Count)],
					bin = n++
				};
				words.Add(w);
			}
		}

		/// <summary>
		/// Check pastebin token and creds validity
		/// </summary>
		/// <param name="force"></param>
		public async void CheckPasteToken(bool force = false) {
			if (user.api_key == "localhost" && !force) {
				Console.WriteLine("Localhost, no connection");
				checkBox1.Checked = false;
				return;
			}

			var post = new Dictionary<string, string>{
						{ "api_dev_key", user.api_key},
						{ "api_user_key", user.user_key },
						{ "api_option", "userdetails" }
			};
			var content = new FormUrlEncodedContent(post);
			return;
			var response = await client.PostAsync("https://pastebin.com/api/api_post.php", content);
			var responseString = await response.Content.ReadAsStringAsync();

			if (!responseString.Contains("<user_name>")) {
				Console.WriteLine("INVALID PASTE TOKEN : " + responseString);
				if (responseString.Contains("invalid")) {
					Form2 form = new() {
						StartPosition = FormStartPosition.CenterParent
					};
					form.ShowDialog();
					user.user_key = form.token;
					user.api_key = form.api_key;
					Console.WriteLine("New use token :" + form.token + " | " + form.api_key);
					File.WriteAllText("user/user_infos.json", JsonConvert.SerializeObject(user, Formatting.Indented));
					CheckPasteToken();
					return;
				}
			} else {
				Console.WriteLine("PASTE USER AUTH OK :\n" + responseString);
				DownloadPastes();
			}
		}


		public async void DeletePaste() {
			var content = new FormUrlEncodedContent(new Dictionary<string, string>{
						{ "api_dev_key", user.api_key},
						{ "api_user_key", user.user_key },
						{ "api_paste_key", "none" },
						{ "api_option", "delete" }
			});

			//POST the object to the specified URI 
			var response = await client.PostAsync("https://pastebin.com/api/api_post.php", content);

			//Read back the answer from server
			var responseString = await response.Content.ReadAsStringAsync();
			Console.WriteLine("DELETE PASTE : " + responseString);
		}

		/// <summary>
		/// Save a paste to pastebin and add paste ID to filename
		/// </summary>
		public async void SavePaste(string path, string data) {
			string fileName = path.Split("\\").Last();

			var values = new Dictionary<string, string>{
						{ "api_dev_key", user.api_key },
						{ "api_user_key", user.user_key},

						{ "api_paste_name", "~PWD~" + fileName},
						{ "api_paste_code", data },
						{ "api_option", "paste"},
						{ "api_paste_private", "2"},
						{ "api_paste_expire_date ", "N"}
				};

			//form "postable object" if that makes any sense
			var content = new FormUrlEncodedContent(values);

			//POST the object to the specified URI 
			var response = await client.PostAsync(url, content);

			//Read back the answer from server
			var responseString = await response.Content.ReadAsStringAsync();
			if (!responseString.StartsWith("https")) {
				Console.WriteLine("Cannot save paste online : " + responseString);
				Console.WriteLine($"Encrypted data saved into :\n{path}");
				File.WriteAllText(path, data);
				return;
			}
			Console.WriteLine("SAVED PASTE : " + responseString);

			string key = responseString.Split("/").Last();
			File.WriteAllText(path.Replace(fileName, key + "_" + fileName), data);
			Console.WriteLine($"Encrypted data saved into :\n{path.Replace(fileName, key + "_" + fileName)}");
		}

		/// <summary>
		/// Download pastes from pastebin
		/// </summary>
		public async void DownloadPastes() {
			var post = new Dictionary<string, string>{
						{ "api_dev_key", user.api_key},
						{ "api_user_key", user.user_key },
						{ "api_option", "list" }
			};
			var content = new FormUrlEncodedContent(post);
			var response = await client.PostAsync("https://pastebin.com/api/api_post.php", content);
			var responseString = await response.Content.ReadAsStringAsync();

			if (!responseString.Contains("<paste_url>")) {
				Console.WriteLine("CAN'T DOWNLOAD PASTES : " + responseString);
				return;
			}

			post["api_option"] = "show_paste";
			post.Add("api_paste_key", "?");

			foreach (var paste in responseString.Split("<paste>", StringSplitOptions.RemoveEmptyEntries)) {
				if (!paste.Contains("</paste_url>")) continue;
				if (!paste.Contains("~PWD~")) {
					continue;
				}
				string key = paste.Split("<paste_key>")[1].Split("</paste_key>")[0];

				string fileName = "data/" + key + "_" + paste.Split("~PWD~")[1].Split(".data")[0] + ".data";
				if (File.Exists(fileName)) {
					Console.WriteLine("Skip >> " + fileName);
					continue;
				}

				string id = paste.Split("</paste_url>")[0].Split("/").Last();
				post["api_paste_key"] = id;
				content = new FormUrlEncodedContent(post);
				response = await client.PostAsync("https://pastebin.com/api/api_post.php", content);
				responseString = await response.Content.ReadAsStringAsync();
				Console.WriteLine("Download >> " + fileName);
				File.WriteAllText(fileName, responseString);
			}
		}

		/// <summary>
		/// When you manualy update yout keyphrase
		/// </summary>
		private void key_phrase_textChanged(object sender, EventArgs e) {
			List<byte> binary = new List<byte>();
			foreach (var w in key_phrase_txt.Text.Replace("\n", String.Empty)
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)) {
				try {
					binary.Add(words.First(wo => wo.value == w).bin);
				} catch (Exception) {
					Console.WriteLine("Error of decoding at word : " + w);
					LoadData.Enabled = false;
					SaveData.Enabled = false;
					data_txt.ReadOnly = true;
					data_txt.ForeColor = Color.Gray;
					return;
				}
			}

			data_txt.ReadOnly = false;
			LoadData.Enabled = true;
			SaveData.Enabled = true;
			data_txt.ForeColor = Color.Gold;
			if (rawData != "") ParseData(rawData, rawIV);
		}
		string GetPassPhrase() {
			return key_phrase_txt.Text.Replace("\n", String.Empty);
		}
		void ParseData(string data, byte[] IV) {
			rawData = data;
			rawIV = IV;
			byte[] binaryData = Convert.FromBase64String(data);
			byte[] key = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(GetPassPhrase()));
			if (key.Length == 0) {
				Console.WriteLine("No key stored, aborting ParseData.");
				return;
			}
			try {
				data_txt.Text = Decrypt(binaryData, key, IV);
			} catch (Exception) {
				data_txt.Text = "Error decryption";
			}
		}
		private void GenerateKeyPhrase() {
			string txt = "";
			byte[] binary = new byte[32];
			csp.GetBytes(binary);
			int n = 0;
			foreach (var b in binary) {
				txt += words.First(w => w.bin == b).value + " ";
				n++;
			}
			key_phrase_txt.Text = txt.TrimEnd(' ');
		}
		private void SaveSecretDataClickAsync(object sender, EventArgs e) {
			dialog.InitialDirectory = Application.StartupPath + "data";
			dialog.Title = "Save your encrypted data";
			dialog.DefaultExt = "data";
			dialog.Filter = "encrypted data|*.data";
			dialog.CheckFileExists = false;
			if (dialog.ShowDialog() == DialogResult.OK) {

				byte[] key = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(GetPassPhrase()));
				byte[] IV = new byte[16];
				csp.GetBytes(IV);

				string encryptedData = Convert.ToBase64String(Encrypt(data_txt.Text, key, IV));

				Console.WriteLine("Data : " + encryptedData);
				string data = "----------DATA----------\n" + encryptedData + "\n------END-OF--DATA------\n";
				data += "----------IV------------\n" + Convert.ToBase64String(IV) + "\n-------END--OF--IV------";
				if (checkBox1.Checked) {
					SavePaste(dialog.FileName, data);
				} else {
					File.WriteAllText(dialog.FileName, data);
					Console.WriteLine($"Encrypted data saved into :\n{dialog.FileName}");
				}
			}
		}
		private void LoadEncryptedData(object sender, EventArgs e) {
			dialog.InitialDirectory = Application.StartupPath + "data";
			dialog.Title = "Select your data file;";
			dialog.DefaultExt = "data";
			dialog.Filter = "data|*.data";
			if (dialog.ShowDialog() == DialogResult.OK) {
				var file = File.ReadAllText(dialog.FileName);
				string data = file.Split("------END-OF--DATA------")[0]
					.Replace("----------DATA----------", "")
					.Replace("\n", "").TrimStart('\n');
				string IV = file.Split("----------IV------------")[1]
					.Replace("-------END--OF--IV------", "")
					.Replace("\n", "").TrimStart('\n');
				ParseData(data, Convert.FromBase64String(IV));
			}
		}
		private void data_txt_TextChanged(object sender, EventArgs e) {
			data_txt.ForeColor = data_txt.ReadOnly ? Color.Gray : Color.Gold;
		}
		private void checkBox1_CheckedChanged(object sender, EventArgs e) {
			checkBox1.ForeColor = checkBox1.Checked ? Color.Gold : Color.Gray;
			if (checkBox1.Checked) CheckPasteToken(true);
		}
		private void button1_Click(object sender, EventArgs e) {
			byte[] rand = new byte[20];
			csp.GetBytes(rand);
			string pass = Convert.ToBase64String(rand);
			Clipboard.SetText(pass);
			data_txt.Text += pass;
		}
		private void textBox1_TextChanged(object sender, EventArgs e) {
			CheckPass();
		}
		private void textBox2_TextChanged(object sender, EventArgs e) {
			CheckPass();
		}
		void CheckPass() {
			string txt = pass1Tb.Text;
			var hasNumber = new Regex(@"[0-9]+");
			var hasUpperChar = new Regex(@"[A-Z]+");
			var hasMinimum8Chars = new Regex(@".{8,}");
			bool match = hasNumber.IsMatch(txt) && hasUpperChar.IsMatch(txt) && hasMinimum8Chars.IsMatch(txt);
			CreatePasse.Enabled = pass1Tb.Text == pass2Tb.Text && match;
			label3PasswordStrong.Visible = !CreatePasse.Enabled;
			if (pass1Tb.Text != pass2Tb.Text) label3PasswordStrong.Text = "Passwords does not match";
			else label3PasswordStrong.Text = "Password is not secure.";
		}
		private void CreatePasse_Click(object sender, EventArgs e) {
			Console.WriteLine("Private key not found, creating new one !");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("!!! BE CAREFULL !!! Deleting that list will lose all saved data ! (in /user/key.key)");
			Console.ForegroundColor = ConsoleColor.White;

			GenerateKeyPhrase();
			string passPhrase = key_phrase_txt.Text;
			byte[] personalPass = Encoding.UTF8.GetBytes(pass1Tb.Text);

			byte[] key = MD5.Create().ComputeHash(personalPass);
			byte[] IV = new byte[16];
			csp.GetBytes(IV);
			string base64Key = Convert.ToBase64String(Encrypt(passPhrase, key, IV));

			File.WriteAllText($"user/key.key", base64Key);
			File.WriteAllText($"user/IV.vector", Convert.ToBase64String(IV));
			MainPanel.Visible = true;
			panel1Register.Visible = false;
		}
		private void GetPrivatePhrase(object sender, EventArgs e) {
			byte[] base64Key = Convert.FromBase64String(File.ReadAllText($"user/key.key"));
			byte[] IV = Convert.FromBase64String(File.ReadAllText($"user/IV.vector"));
			byte[] personalPass = Encoding.UTF8.GetBytes(passAuthTb.Text);
			byte[] key = MD5.Create().ComputeHash(personalPass);

			try {
				string passPhrase = Decrypt(base64Key, key, IV);
				foreach (var item in passPhrase.Split(" ")) {
					if (words.Find(w => w.value == item) == null) {
						label3ErrPass.Visible = true;
						return;
					}
				}
				MainPanel.Visible = true;
				panel2Auth.Visible = false;
				key_phrase_txt.Text = passPhrase;
				key_phrase_textChanged(this, null);
			} catch (Exception) {
				label3ErrPass.Visible = true;
				return;
			}
		}
		static byte[] Encrypt(string plainText, byte[] Key, byte[] IV) {
			byte[] encrypted;
			// Create a new AesManaged.    
			using (Aes aes = Aes.Create()) {
				// Create encryptor    
				ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
				// Create MemoryStream    
				using MemoryStream ms = new();
				// Create crypto stream using the CryptoStream class. This class is the key to encryption    
				// and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
				// to encrypt    
				using CryptoStream cs = new(ms, encryptor, CryptoStreamMode.Write);
				// Create StreamWriter and write data to a stream    
				using (StreamWriter sw = new(cs))
					sw.Write(plainText);
				encrypted = ms.ToArray();
			}
			// Return encrypted data    
			return encrypted;
		}

		static public byte[] EncryptionRSA(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding) {
			try {
				byte[] encryptedData;
				using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider()) {
					RSA.ImportParameters(RSAKey);
					encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
				}
				return encryptedData;
			} catch (CryptographicException e) {
				Console.WriteLine(e.Message);
				return null;
			}
		}
		static public byte[] DecryptionRSA(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding) {
			try {
				byte[] decryptedData;
				using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider()) {
					RSA.ImportParameters(RSAKey);
					decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
				}
				return decryptedData;
			} catch (CryptographicException e) {
				Console.WriteLine(e.ToString());
				return null;
			}
		}

		static string Decrypt(byte[] cipherText, byte[] Key, byte[] IV) {
			string? plaintext = null;
			// Create AesManaged    
			using (Aes aes = Aes.Create()) {
				// Create a decryptor    
				ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
				// Create the streams used for decryption.    
				using MemoryStream ms = new(cipherText);
				// Create crypto stream    
				using CryptoStream cs = new(ms, decryptor, CryptoStreamMode.Read);
				// Read crypto stream    
				using StreamReader reader = new(cs);
				plaintext = reader.ReadToEnd();
			}
			return plaintext;
		}

		private void demoTxt_TextChanged(object sender, EventArgs e) {
			byte[] binaryText = Encoding.UTF8.GetBytes(demoTxt.Text);
			demoHexaTxt.Text = BitConverter.ToString(binaryText);

			byte[] binaryKey = Encoding.UTF8.GetBytes(demoKey.Text);
			demoHexaKey.Text = BitConverter.ToString(binaryKey);
			byte[] hashKey = MD5.Create().ComputeHash(binaryKey);
			demoHashKey.Text = BitConverter.ToString(hashKey);

			try {
				byte[] encrypted = Encrypt(demoTxt.Text, hashKey, IV);
				demoEncrypted.Text = BitConverter.ToString(encrypted);
				cipherTxt = encrypted;
				aesEncryptedRsa = EncryptionRSA(hashKey, RSA.ExportParameters(false), true);
				demoAesKeyRsa.Text = BitConverter.ToString(aesEncryptedRsa);
			} catch (Exception ex) {
				demoEncrypted.Text = ex.Message;
			}
		}

		byte[] IV = new byte[0];
		private void button2_Click(object sender, EventArgs e) {
			IV = new byte[16];
			csp.GetBytes(IV);
			demoIV.Text = BitConverter.ToString(IV);
			try {
				byte[] binaryKey = Encoding.UTF8.GetBytes(demoKey.Text);
				byte[] hashKey = MD5.Create().ComputeHash(binaryKey);
				byte[] encrypted = Encrypt(demoTxt.Text, hashKey, IV);
				demoEncrypted.Text = BitConverter.ToString(encrypted);
			} catch (Exception ex) {
				demoEncrypted.Text = ex.Message;
			}
		}

		RSACryptoServiceProvider RSA = new();
		byte[] aesEncryptedRsa = new byte[0];
		byte[] cipherTxt = new byte[0];
		private void button4_Click(object sender, EventArgs e) {
			RSA = new RSACryptoServiceProvider();
			demoRSA.Text = RSA.ToXmlString(true)/*.Replace(">", ">\n").Replace("</", "\n</").TrimStart('\n')*/;
			byte[] binaryKey = Encoding.UTF8.GetBytes(demoKey.Text);
			byte[] hashKey = MD5.Create().ComputeHash(binaryKey);
			aesEncryptedRsa = EncryptionRSA(hashKey, RSA.ExportParameters(false), true);
			demoAesKeyRsa.Text = BitConverter.ToString(aesEncryptedRsa);
		}

		private void demoAesKeyRsa_TextChanged(object sender, EventArgs e) {
			try {
				var aes = DecryptionRSA(aesEncryptedRsa, RSA.ExportParameters(true), true);
				//byte[] cipher = .Select(value => Convert.ToByte(value, 16)).ToArray();
				var txt = Decrypt(cipherTxt, aes, IV);
				decryptedText.Text = txt;
			} catch(Exception ex) {
				decryptedText.Text = ex.Message;
			}
		}

		private void demoRSA_TextChanged(object sender, EventArgs e) {
			if (!demoRSA.Text.Contains("</")) return;
			try {
				RSA.FromXmlString(demoRSA.Text/*.Remove('\n')*/);
				demoRSA.ForeColor = Color.Gold;
			} catch (Exception ex) {
				demoRSA.Text = ex.Message;
				demoRSA.ForeColor = Color.Red;
			}
		}
	}
}
