using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ePrint.WebStore.Constants
{
    public static class Constants
    {
        public static string GoogleTagManagerScript_HandyExpress = @"<!-- Google Tag Manager -->
                    <script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
                    new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
                    j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
                    'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
                    })(window,document,'script','dataLayer','GTM-T67RLSS');</script>
                    <!-- End Google Tag Manager -->";




        public static string LanguageConversionScript_HandyExpress = @"
                                < !--Google Code for SALE COMPLETE Conversion Page-- >
                         < script type =\""text/javascript\\"">
                         /* <![CDATA[ */
                         var google_conversion_id = 802082731;
                                        var google_conversion_label = \""durNCIK5hoUBEKufu_4C\"";
                                        var google_remarketing_only = false;
                        /* ]]> */
                        </ script >
                        < script type =\""text/javascript\\"" src=\""//www.googleadservices.com/pagead/conversion.js\\"">
                          </ script >
                          < noscript >
                          < div style =\\""display:inline;\\"">
                            < img height =\""1\"" width=\""1\"" style=\""border-style:none;\\"" alt="" src=\""//www.googleadservices.com/pagead/conversion/802082731/?label=durNCIK5hoUBEKufu_4C&amp;guid=ON&amp;script=0\""/>
                              </ div >
                              </ noscript > ";
    }
}