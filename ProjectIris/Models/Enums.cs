using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectIris.Models
{
    public class Enums
    {
        public List<string> TitleDropDowns()
        {
            List<string> titles = new List<string>();
            foreach (Title title in Enum.GetValues(typeof(Title)))
            {
                titles.Add(title.ToString());
            }
            return titles;
        }

        public List<string> MarriedStatusDropDowns()
        {
            List<string> status = new List<string>();
            foreach (MarriedStatus ms in Enum.GetValues(typeof(MarriedStatus)))
            {
                status.Add(ms.ToString());
            }
            return status;
        }

        public List<string> CountriesDropDowns()
        {
            List<string> countries = new List<string>();
            foreach (Countries c in Enum.GetValues(typeof(Countries)))
            {
                countries.Add(c.ToString());
            }
            return countries;
        }

        public List<string> EmploymentDropDowns()
        {
            List<string> employment = new List<string>();
            foreach (Employment e in Enum.GetValues(typeof(Employment)))
            {
                employment.Add(e.ToString());
            }
            return employment;
        }

        public List<string> NationalityDropDowns()
        {
            List<string> nationalities = new List<string>();
            foreach (Nationality n in Enum.GetValues(typeof(Nationality)))
            {
                nationalities.Add(n.ToString());
            }
            return nationalities;
        }

        public List<string> AccountTypesDropDowns()
        {
            List<string> accounttypes = new List<string>();
            foreach (AccountTypes at in Enum.GetValues(typeof(AccountTypes)))
            {
                accounttypes.Add(at.ToString());
            }
            return accounttypes;
        }

        //public List<string> BanksDropDowns()
        //{
        //    List<string> banks = new List<string>();
        //    foreach (Banks b in Enum.GetValues(typeof(Banks)))
        //    {
        //        banks.Add(b.ToString());
        //    }
        //    return banks;
        //}

        //public List<string> SwiftCodeDropDowns()
        //{
        //    List<string> swiftcodes = new List<string>();
        //    foreach (SwiftCode sc in Enum.GetValues(typeof(SwiftCode)))
        //    {
        //        swiftcodes.Add(sc.ToString());
        //    }
        //    return swiftcodes;
        //}
    }

    public enum Title
    {
        Mr,
        Ms,
        Mrs
    }

    public enum MarriedStatus
    {
        Single,
        Married
    }

    public enum Employment
    {
        Fulltime,
        Parttime
    }

    public enum Nationality
    {
        Afghan,
        Albanian,
        Algerian,
        American,
        Andorran,
        Angolan,
        Argentine,
        Armenian,
        Aromanian,
        Aruban,
        Australian,
        Austrian,
        Azeri,
        Bahamian,
        Bahraini,
        Bangladeshi,
        Barbadian,
        Belarusian,
        Belgian,
        Belizean,
        Bermudian,
        Boer,
        Bosniak,
        Brazilian,
        Breton,
        British,
        Bulgarian,
        Burkinabè,
        Burundian,
        Cambodian,
        Cameroonian,
        Canadian,
        Catalan,
        Cape_Verdean,
        Chadian,
        Chilean,
        Chinese,
        Colombian,
        Comorian,
        Congolese,
        Croatian,
        Cuban,
        Cypriots_Turkish_Cypriot,
        Czech,
        Dane,
        Dominican_Republic,
        Dominican_Commonwealth,
        Dutch,
        East_Timorese,
        Ecuadorian,
        Egyptian,
        Emirati,
        English,
        Eritrean,
        Estonian,
        Ethiopian,
        Faroese,
        Finnish,
        Finnish_Swedish,
        Fijian,
        Filipino,
        French,
        Georgian,
        German,
        Ghanaian,
        Gibraltar,
        Greek,
        Grenadian,
        Guatemalan,
        Guianese,
        Guinean,
        Guinea_Bissau_National,
        Guyanese,
        Haitian,
        Honduran,
        Hong_Kong,
        Hungarian,
        Icelander,
        Indian,
        Indonesian,
        Iranian,
        Iraqi,
        Irish,
        Israeli,
        Italian,
        Ivoirian,
        Jamaican,
        Japanese,
        Jordanian,
        Kazakh,
        Kenyan,
        Korean,
        Kosovar,
        Kurd,
        Kuwaiti,
        Kyrgyz,
        Lao,
        Latvian,
        Lebanese,
        Liberian,
        Libyan,
        Liechtensteiner,
        Lithuanian,
        Luxembourger,
        Macedonian,
        Malagasy,
        Malaysian,
        Malawian,
        Maldivian,
        Malian,
        Maltese,
        Manx,
        Mauritian,
        Mexican,
        Moldovan,
        Moroccan,
        Mongolian,
        Montenegrin,
        Namibian,
        Nepalese,
        New_Zealander,
        Nicaraguan,
        Nigerien,
        Nigerian,
        Norwegian,
        Pakistani,
        Palauan,
        Palestinian,
        Panamanian,
        Paraguayan,
        Peruvian,
        Pole,
        Portuguese,
        Puerto_Rican,
        Quebecer,
        Réunionnai,
        Romanian,
        Russian,
        Rwandan,
        Salvadoran,
        Saudi,
        Scot,
        Senegalese,
        Serb,
        Sierra_Leonean,
        Singaporean,
        Sindhian,
        Slovak,
        Slovene,
        Somali,
        South_African,
        Spaniard,
        Sri_Lankan,
        St_Lucian,
        Sudanese,
        Surinamese,
        Swede,
        Swiss,
        Syriac,
        Syrian,
        Taiwanese,
        Tanzanian,
        Thai,
        Tibetan,
        Tobagonian,
        Trinidadian,
        Tunisian,
        Turk,
        Tuvaluan,
        Ugandan,
        Ukrainian,
        Uruguayan,
        Uzbek,
        Vanuatuans,
        Venezuelan,
        Vietnamese,
        Welsh,
        Yemeni,
        Zambian,
        Zimbabwean
    }

    public enum Countries
    { 
        Afghanistan,
        Albania,
        Algeria,
        Andorra,
        Angola,
        Antigua_Barbuda,
        Argentina,
        Armenia,
        Aruba,
        Australia,
        Austria,
        Azerbaijan,
        Bahamas,
        Bahrain,
        Bangladesh,
        Barbados,
        Belarus,
        Belgium,
        Belize,
        Benin,
        Bhutan,
        Bolivia,
        Bosnia_Herzegovina,
        Botswana,
        Brazil,
        Brunei,
        Bulgaria,
        Burkina_Faso,
        Burma,
        Burundi,
        Cambodia,
        Cameroon,
        Canada,
        Cape_Verde,
        Central_African_Republic,
        Chad,
        Chile,
        China,
        Colombia,
        Comoros,
        Congo,
        Costa_Rica,
        Croatia,
        Cuba,
        Curacao,
        Cyprus,
        Czech_Republic,
        Denmark,
        Djibouti,
        Dominica,
        Dominican_Republic,
        Ecuador,
        Egypt,
        El_Salvador,
        Equatorial_Guinea,
        Eritrea,
        Estonia,
        Ethiopia,
        Fiji,
        Finland,
        France,
        Gabon,
        Gambia,
        Georgia,
        Germany,
        Ghana,
        Greece,
        Grenada,
        Guatemala,
        Guinea,
        Guinea_Bissau,
        Guyana,
        Haiti,
        Holy_See,
        Honduras,
        Hong_Kong,
        Hungary,
        Iceland,
        India,
        Indonesia,
        Iran,
        Iraq,
        Ireland,
        Israel,
        Italy,
        Jamaica,
        Japan,
        Jordan,
        Kazakhstan,
        Kenya,
        Kiribati,
        Korea_North,
        Korea_South,
        Kosovo,
        Kuwait,
        Kyrgyzstan,
        Laos,
        Latvia,
        Lebanon,
        Lesotho,
        Liberia,
        Libya,
        Liechtenstein,
        Lithuania,
        Luxembourg,
        Macau,
        Macedonia,
        Madagascar,
        Malawi,
        Malaysia,
        Maldives,
        Mali,
        Malta,
        Marshall_Islands,
        Mauritania,
        Mauritius,
        Mexico,
        Micronesia,
        Moldova,
        Monaco,
        Mongolia,
        Montenegro,
        Morocco,
        Mozambique,
        Namibia,
        Nauru,
        Nepal,
        Netherlands,
        Antilles,
        New_Zealand,
        Nicaragua,
        Niger,
        Nigeria,
        Norway,
        Oman,
        Pakistan,
        Palau,
        Palestinian_Territories,
        Panama,
        Papua_New_Guinea,
        Paraguay,
        Peru,
        Philippines,
        Poland,
        Portugal,
        Qatar,
        Romania,
        Russia,
        Rwanda,
        Saint_Lucia,
        Samoa,
        San_Marino,
        Sao_Tome_and_Principe,
        Saudi_Arabia,
        Senegal,
        Serbia,
        Seychelles,
        Sierra_Leone,
        Singaporem,
        Sint_Maarten,
        Slovakia,
        Slovenia,
        Solomon_Islands,
        Somalia,
        South_Africa,
        South_Korea,
        South_Sudan,
        Spain,
        Sri_Lanka,
        Sudan,
        Suriname,
        Swaziland,
        Sweden,
        Switzerland,
        Syria,
        Taiwan,
        Tajikistan,
        Tanzania,
        Thailand,
        Timor_Leste,
        Togo,
        Tonga,
        Trinidad_Tobago,
        Tunisia,
        Turkey,
        Turkmenistan,
        Tuvalu,
        Uganda,
        Ukraine,
        United_Arab_Emirates,
        United_Kingdom,
        Uruguay,
        Uzbekistan,
        Vanuatu,
        Venezuela,
        Vietnam,
        Yemen,
        Zambia,
        Zimbabwe
    }

    public enum AccountTypes
    {
        SavingsAccount,
        BasicCheckingAccount,
        InterestBearingCheckingAccount,
        MoneyMarketDepositAccount,
        CertificatesOfDeposit
    }

    ////Banks enum size must be the same as swift codes
    //public enum Banks
    //{
    //    AGRIBANK_PLC,
    //    AKBANK_TAS,
    //    APS_BANK_LTD,
    //    BANIF_BANK_PLC,
    //    BANK_OF_VALLETTA,
    //    BAWAG_MALTA_BANK_LTD,
    //    CENTRAL_BANK_OF_MALTA,
    //    CITCO_CUSTODY_LIMITED ,
    //    CREDIT_EUROPE_BANK_NV_MALTA_BRANCH,
    //    CREDORAX_BANK_LIMITED,
    //    ECCM_BANK_PLC,
    //    EFT_GLOBAL_LIMITED,
    //    ESS_DATABRIDGE_EXCHANGE_LIMITED,
    //    FCM_BANK_LIMITED,
    //    FERRATUM_BANK_LIMITED,
    //    FIMBANK_PLC,
    //    GARANTI_BANK_MALTA_BRANCH,
    //    HSBC_BANK_MALTA_PLC,
    //    IIG_BANK_MALTA_LTD,
    //    IZOLA_BANK_MALTA_LTD,
    //    LOMBARD_BANK_MALTA_PLC,
    //    MALTA_STOCK_EXCHANGE,
    //    MEDITERRANEAN_BANK_PLC,
    //    MEDITERRANEAN_CORPORATE_BANK,
    //    NBG_BANK_MALTA_LIMITED,
    //    NEMEA_BANK,
    //    NOVUM_BANK_LTD,
    //    PAYMIX_LIMITED,
    //    PILATUS_BANK_LTD,
    //    SATABANK_PLC,
    //    W_AND_J_COPPINI_AND_CO,
    //    WESTERN_UNION_BUSINESS_SOLUTIONS_MALTA_LTD,
    //    YAPI_KREDI_BANK_MALTA_LTD
    //}

    ////Swift Code enum size must be the same as bank enums
    //public enum SwiftCode
    //{
    //    AGRKMTMT,
    //    AKBKMTMT,
    //    APSBMTMT,
    //    BNIFMTMT,
    //    VALLMTMT,
    //    BAWAMTM3,
    //    MALTMTMT,
    //    CITCMTMT,
    //    FBHLMTMT,
    //    CRXBMTMT,
    //    ECMBMTMT,
    //    EFTGMTM2,
    //    ESSDMTMT,
    //    FCMFMTMT,
    //    FEMAMTMT,
    //    FIMBMTM3,
    //    TGBAMTMT,
    //    MMEBMTMT,
    //    IIGBMTMT,
    //    IZOLMTMT,
    //    LBMAMTMT,
    //    XMALMTMT,
    //    MBWMMTMT,
    //    VBMAMTM3,
    //    FNNBMTMT,
    //    NMEAMTMT,
    //    VOCBMTMT,
    //    PYMXMTMT,
    //    PLTSMTMT,
    //    STBAMTMT,
    //    COPXMTMT,
    //    TGBPMTMT,
    //    YAPIMTMT
    //}
}