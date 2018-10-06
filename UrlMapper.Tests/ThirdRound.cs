using FluentAssertions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace UrlMapper.Tests
{
    public class ThirdRound
    {
        private IList<PerformanceTesting> cases = new List<PerformanceTesting>();

        public ThirdRound()
        {
            setupInput("www.something.org/{p1}/", "www.something.org/1/", "{p1}", "1");
            setupInput("www.something.org/{p1}/{p2}/", "www.something.org/1/2/", "{p1},{p2}", "1,2");
            setupInput("www.something.org/{p1}/{p2}/{p3}/", "www.something.org/1/2/3/", "{p1},{p2},{p3}", "1,2,3");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/", "www.something.org/1/2/3/4/", "{p1},{p2},{p3},{p4}", "1,2,3,4");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/", "www.something.org/1/2/3/4/5/", "{p1},{p2},{p3},{p4},{p5}", "1,2,3,4,5");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/", "www.something.org/1/2/3/4/5/6/", "{p1},{p2},{p3},{p4},{p5},{p6}", "1,2,3,4,5,6");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/", "www.something.org/1/2/3/4/5/6/7/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7}", "1,2,3,4,5,6,7");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/", "www.something.org/1/2/3/4/5/6/7/8/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8}", "1,2,3,4,5,6,7,8");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/", "www.something.org/1/2/3/4/5/6/7/8/9/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9}", "1,2,3,4,5,6,7,8,9");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10}", "1,2,3,4,5,6,7,8,9,10");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11}", "1,2,3,4,5,6,7,8,9,10,11");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12}", "1,2,3,4,5,6,7,8,9,10,11,12");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13}", "1,2,3,4,5,6,7,8,9,10,11,12,13");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/{p27}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26},{p27}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/{p27}/{p28}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26},{p27},{p28}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/{p27}/{p28}/{p29}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26},{p27},{p28},{p29}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/{p27}/{p28}/{p29}/{p30}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26},{p27},{p28},{p29},{p30}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/{p27}/{p28}/{p29}/{p30}/{p31}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26},{p27},{p28},{p29},{p30},{p31}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/{p27}/{p28}/{p29}/{p30}/{p31}/{p32}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26},{p27},{p28},{p29},{p30},{p31},{p32}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/{p27}/{p28}/{p29}/{p30}/{p31}/{p32}/{p33}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26},{p27},{p28},{p29},{p30},{p31},{p32},{p33}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/{p27}/{p28}/{p29}/{p30}/{p31}/{p32}/{p33}/{p34}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26},{p27},{p28},{p29},{p30},{p31},{p32},{p33},{p34}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/{p27}/{p28}/{p29}/{p30}/{p31}/{p32}/{p33}/{p34}/{p35}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26},{p27},{p28},{p29},{p30},{p31},{p32},{p33},{p34},{p35}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/{p27}/{p28}/{p29}/{p30}/{p31}/{p32}/{p33}/{p34}/{p35}/{p36}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26},{p27},{p28},{p29},{p30},{p31},{p32},{p33},{p34},{p35},{p36}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/{p27}/{p28}/{p29}/{p30}/{p31}/{p32}/{p33}/{p34}/{p35}/{p36}/{p37}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26},{p27},{p28},{p29},{p30},{p31},{p32},{p33},{p34},{p35},{p36},{p37}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/{p27}/{p28}/{p29}/{p30}/{p31}/{p32}/{p33}/{p34}/{p35}/{p36}/{p37}/{p38}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26},{p27},{p28},{p29},{p30},{p31},{p32},{p33},{p34},{p35},{p36},{p37},{p38}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/{p27}/{p28}/{p29}/{p30}/{p31}/{p32}/{p33}/{p34}/{p35}/{p36}/{p37}/{p38}/{p39}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26},{p27},{p28},{p29},{p30},{p31},{p32},{p33},{p34},{p35},{p36},{p37},{p38},{p39}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39");
            setupInput("www.something.org/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/{p27}/{p28}/{p29}/{p30}/{p31}/{p32}/{p33}/{p34}/{p35}/{p36}/{p37}/{p38}/{p39}/{p40}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/", "{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26},{p27},{p28},{p29},{p30},{p31},{p32},{p33},{p34},{p35},{p36},{p37},{p38},{p39},{p40}", "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40");
            setupInput("{p0}/{p1}/{p2}/{p3}/{p4}/{p5}/{p6}/{p7}/{p8}/{p9}/{p10}/{p11}/{p12}/{p13}/{p14}/{p15}/{p16}/{p17}/{p18}/{p19}/{p20}/{p21}/{p22}/{p23}/{p24}/{p25}/{p26}/{p27}/{p28}/{p29}/{p30}/{p31}/{p32}/{p33}/{p34}/{p35}/{p36}/{p37}/{p38}/{p39}/{p40}/", "www.something.org/1/2/3/4/5/6/7/8/9/10/11/12/13/14/15/16/17/18/19/20/21/22/23/24/25/26/27/28/29/30/31/32/33/34/35/36/37/38/39/40/", "{p0},{p1},{p2},{p3},{p4},{p5},{p6},{p7},{p8},{p9},{p10},{p11},{p12},{p13},{p14},{p15},{p16},{p17},{p18},{p19},{p20},{p21},{p22},{p23},{p24},{p25},{p26},{p27},{p28},{p29},{p30},{p31},{p32},{p33},{p34},{p35},{p36},{p37},{p38},{p39},{p40}", "www.something.org,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40");
        }

        [Theory(DisplayName = "Builder can perform a ton of cases well as it could be")]
        [InlineData(1, 30)]
        [InlineData(10, 30)]
        [InlineData(100, 30)]
        [InlineData(1000, 30)]
        public void PerformanceTestForBuilder(int rounds, int expectedDoneInSeconds)
        {
            var timer = new Stopwatch();
            timer.Start();
            for (int round = 0; round < rounds; round++)
            {
                foreach (var it in cases)
                {
                    var builder = FirstRound.Builder;
                    var sut = builder.Parse(it.Pattern);

                    var actual = new Dictionary<string, string>();
                    var isMatch = sut.IsMatched(it.URL);
                    isMatch.Should().Be(it.ExpectedMatchedResult);
                    sut.ExtractVariables(it.URL, actual);
                    actual.Should().NotBeNull();
                    Assert.Equal(it.ExpectedExtractValues.Count, actual.Count);
                    Assert.True(actual.Keys.All(a => it.ExpectedExtractValues.ContainsKey(a)));
                    foreach (var expected in it.ExpectedExtractValues)
                    {
                        expected.Value.Should().BeEquivalentTo(actual[expected.Key]);
                    }
                }
            }
            timer.Stop();
            timer.Elapsed.TotalSeconds.Should().BeLessOrEqualTo(expectedDoneInSeconds);
        }

        private void setupInput(string pattern, string url, string keys, string values, bool expectedMatched = true, string splitter = ",")
        {
            var expectedDic = new Dictionary<string, string>();
            var expectedKeys = keys.Split(splitter);
            var expectedValues = values.Split(splitter);

            for (int elementIndex = 0; elementIndex < expectedKeys.Length; elementIndex++)
                expectedDic.Add(expectedKeys[elementIndex], expectedValues[elementIndex]);

            cases.Add(new PerformanceTesting
            {
                Pattern = pattern,
                URL = url,
                ExpectedExtractValues = expectedDic,
                ExpectedMatchedResult = expectedMatched
            });
        }


        private class PerformanceTesting
        {
            public string Pattern { get; set; }
            public string URL { get; set; }
            public IDictionary<string, string> ExpectedExtractValues { get; set; }
            public bool ExpectedMatchedResult { get; set; }
        }
    }
}