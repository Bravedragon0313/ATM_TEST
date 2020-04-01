function calcNumbers(result) {
    if (document.getElementById('DisplayResult').value.length > 3) {
        return false;
    }
    document.getElementById('DisplayResult').value += result;
}

function withdrawamount(result) {
    if (document.getElementById('withdraw_sumamount').value.length > 3) {
        return false;
    }
    document.getElementById('withdraw_sumamount').value += result;
}

function insertAmount(result) {
    if (document.getElementById('deposit_sumamount').value.length > 3) {
        return false;
    }
    document.getElementById('deposit_sumamount').value += result;
}

function transferAmount(result) {
    if (document.getElementById('transfer_sumamount').value.length > 3) {
        return false;
    }
    document.getElementById('transfer_sumamount').value += result;
}

function cancel() {
    var oldStr = document.getElementById('DisplayResult').value;
    var newStr = oldStr.substr(0, oldStr.length - 1);
    document.getElementById('DisplayResult').value = newStr;
}

function reloadUI() {
    location.reload();
}

var Translations = {
    en: {
        languages: {
            "btn_selectlanguage_czech": "Czech",
            "btn_selectlanguage_english": "English",
            "btn_selectlanguage_french": "French",
            "btn_selectlanguage_magyar": "Magyar",
            "btn_selectlanguage_deutch": "Deutch",
        },
        scanqrcode: {
            "header_scanqrcode_welcome": "Welcome to AppUmbrella Ecosystem.",
            "header_scanqrcode_QRscan": "To continue, please scan your QR code.",
            "error_scanqrcode_error": "Error",
            "error_scanqrcode_again": "Please scan your QR code again.",
            "error_scanqrcode_error2": "Error",
            "error_scanqrcode_again2": "Please scan your QR code again.",
        },
        home: {
            "header_home_welcome": "Welcome to AppUmbrella Ecosystem.",
            "header_home_qrscan": "To continue, please scan your QR code.",
            "text_home_continue": "Tap to continue.",
        },
        smsvalidation: {
            "description_smsvalidation_smstodevice": "An SMS code has been sent to your device.",
            "description_blocksms_smstodevice": "An SMS code has been sent to your device.",
            "description_smsvalidation_enter": "Please enter",
            "description_smsvalidation_authentication": "SMS authorization code",
            "error_smsvalidation_red": "Error.",
            "error_smsvalidation_again": "Please try again.",
            "error_smsvalidation_enter": "Enter SMS code.",
        },
        banknotes: {
            "btn_banknotes_withdrawal": "Withdrawal",
            "btn_banknotes_deposit": "Deposit",
            "btn_banknotes_aupay": "AuPay",
            "description_banknotes_insert": "Insert and withdraw banknotes individually!",
        },
        confirmamount: {
            "btn_confirmamount_another": "Another",
            "btn_confirmamount_sum": "Sum",
            "description_confirmamount_banknotes": "Banknotes will be given one by one!",
            "btn_confirmamount_closing": "End",
        },
        print: {
            "head_print_certification": "Do you wish to print certificate for this transaction?",
            "btn_print_no": "No",
            "btn_print_yes": "Yes",
            "btn_print_closing": "End",
        },
        continue: {
            "head_continue_continue": "Thank you. continue?",
            "btn_continue_no": "No",
            "btn_continue_yes": "Yes",
            "btn_continue_close": "End"
        },
        removecash: {
            "description_removecash_take": "Please&nbsp;take&nbsp;your&nbsp;cash.",
            "description_removecash_giveout": "ATM&nbsp;give&nbsp;out",
            "description_removecash_banknotes": "banknotes&nbsp;one&nbsp;by&nbsp;one!",
            "btn_removecash_closing": "End",
        },
        usingservice: {
            "header_usingservice_thanksforuse": "Thank you for using our services.",
            "btn_usingservice_logout": "Log out",
            "btn_usingservice_continue": "Continue",
        },
        transactioncancel: {
            "description_transactioncancel_cancel": "Transaction&nbsp;cancelled.",
        },
        withdrawamount: {
            "description_withdrawamount_write500": "Please write multiple of CZK 500!",
            "error_withdrawamount_error": "Wrong sum.",
            "error_withdrawamount_again": "Please write sum again.",
            "btn_withdrawamount_closing": "End",
            "error_withdrawamount_toohigherr": "lack of cash in your wallet",
            "error_withdrawamount_notenougherr": "lack of banknotes available",
        },
        banknote: {
            "btn_banknote_withdrawal": "Withdrawal",
            "btn_banknote_deposit": "Deposit",
            "btn_banknote_aupay": "AuPay",
            "description_banknote_insert": "Insert and withdraw banknotes individually!",
        },
        depositamount: {
            "header_depositamount_deposite": "How much do you want to deposit?",
            "header_depositamount_accept": "ATM accept banknotes of value",
            "header_depositamount_amount": "500 Kč, 1000 Kč a 2000 Kč.",
            "error_depositamount_wrongsum": "Wrong sum.",
            "error_depositamount_sumagain": "Please write sum again.",
            "btn_depositamount_closing": "End",
        },
        transferamount: {
            "header_transferamount_deposite": "How much do you want to transfer?",
            "header_transferamount": "ATM accept banknotes of value",
            "header_transferamount": "500 Kč, 1000 Kč a 2000 Kč.",
            "error_transferamount": "Wrong sum.",
            "error_transferamount_sumagain": "Please write sum again.",
            "btn_transferamount_closing": "End",
        },
        Insertbanknotes: {
            "header_insertbanknotes_insert": "Insert banknotes.",
            "header_insertbanknotes_accept": "ATM accept banknotes of value",
            "header_insertbanknotes_amount": "500 Kč, 1000 Kč a 2000 Kč.",
            "description_insertbanknotes_putin": "Please put in banknotes",
            "description_insertbanknotes_individually": "one by one",
            "label_insertbanknotes_paid": "Paid",
            "label_insertbanknotes_tobepaid": "Remain",
            "label_insertbanknotes_sum": "Total",
            "btn_insertbanknotes_confirm": "Confirm",
            "btn_insertbanknotes_closing": "End",

        },
        InsertBanknotes: {
            "header_InsertBanknotes_insert": "Insert banknotes.",
            "header_InsertBanknotes_accept": "ATM accept banknotes of value",
            "header_InsertBanknotes_amount": "500 Kč, 1000 Kč a 2000 Kč.",
            "description_InsertBanknotes_putin": "Please put in banknotes",
            "description_InsertBanknotes_individually": "one by one",
            "label_InsertBanknotes_paid": "Paid",
            "label_InsertBanknotes_tobepaid": "Remain",
            "label_InsertBanknotes_sum": "Total",
            "btn_InsertBanknotes_confirm": "Confirm",
            "btn_InsertBanknotes_closing": "End",
            "filed_required": "All filed required",
            "description_insertBanknotes_wrong": "wrong insert value",
        },
        InsertBanknote: {
            "header_InsertBanknote_insert": "Insert banknotes.",
            "header_InsertBanknote_accept": "ATM accept banknotes of value",
            "header_InsertBanknote_amount": "500 Kč, 1000 Kč a 2000 Kč.",
            "description_InsertBanknote_putin": "Please put in banknotes",
            "description_InsertBanknote_individually": "one by one",
            "label_InsertBanknote_paid": "Paid",
            "label_InsertBanknote_tobepaid": "Remain",
            "label_InsertBanknote_sum": "Total",
            "btn_InsertBanknote_confirm": "Confirm",
            "btn_InsertBanknote_closing": "End",
        },
        deposit: {
            "header_deposit_amount": "Amount deposited",
            "btn_deposite_sendviaaupay": "Send via AuPay",
            "btn_deposite_tomyaccount": "To my account",
            "btn_deposite_closing": "End",
        },
        DepositeQR: {
            "header_DepositeQR_viaaupay": "Deposit via AuPay",
            "header_DepositeQR_scan": "Please scan QR code of receiver",
            "error_DepositeQR_error": "Error.",
            "error_DepositeQR_qragain": "Please scan your QR code again.",
            "btn_DepositeQR_closing": "End",
        },
        confirmrecipitent: {
            "header_confirmrecipitent_amountdeposited": "Amount deposited",
            "description_confirmrecipitent_recipient": "Recipient: Don Ready",
            "btn_confirmrecipitent_confirm": "Confirm",
            "btn_confirmrecipitent_closing": "End",
        },
        connectethernet: {
            "header_connectethernet_networkdown": "Network down",
            "description_connectethernet_verify": "Please connect Ethernet cable or verify its connection.",
        },
        bootingup: {
            "header_bootingup_bootingup": "Booting up...",
            "description_bootingup_initialhardware": "Initializing hardware.",
            "description_bootingup_moment": "We'll be up in a moment.",
        },
        initializing: {
            "header_initializing_initializing": "Initializing...",
            "description_initializing_cryptographicidentity": "Generating cryptographic identity.",
            "description_initializing_wait": "Please wait a few minutes.",
        },
        connecting: {
            "head_connecting_connecting": "Connecting...",
        },
        pairing: {
            "head_pairing_pairing": "Pairing...",
        },
        pairingerror: {
            "head_pairing_pairingfailed": "Pairing failed",
            "description_pairing_error": "When attempting to pair, we experienced an error:",
            "btn_pairing_again": "Try again",
        },
        pairingscan: {
            "head_pairingscan_pair": "Pair with remote server",
            "description_pairingscan_scanqr": "Please scan the pairing QR code you got from your remote server.",
            "btn_pairingscan_cancel": "Cancel",
        },
        virgin: {
            "head_virgin_congratulations": "Congratulations!",
            "description_virgin_welcome": "Welcome to your new ATM.",
            "description_virgin_initialize": "Press initialize to generate a secure cryptographic certificate for your machine. This could take about fifteen minutes.",
            "btn_virgin_initialize": "Initialize",
            "description_virgin_generatecertificate": "Inicializovat",
        },
        maintenance: {
            "head_maintenance_required": "Maintenance Required",
            "description_maintenance_contactoperator": "Please contact the operator.",
        },
        depositenetworkdown: {
            "head_depositenetworkdown_networkdown": "Network Down",
            "description_depositenetworkdown_downmoment": "Sorry, we're down for the moment.",
            "description_depositenetworkdown_comback": "Please come back later.",
            "btn_depositenetworkdown_ok": "OK",
        },
        wificonnecting: {
            "head_wificonnecting_connecting": "Connecting...",
        },
        unpaired: {
            "head_unpaired_pair": "Pair with remote server",
            "description_unpaired_scanqr": "Press SCAN and preset the machine with the pairing QR code from your remote server.",
            "description_unpaired_important": "IMPORTANT: Keep the machine secure until you have successfully paired with your remote server.",
        },
        disconnect: {
            "head_disconnect_fail": "Failed to connect to machine",
            "text_disconnect_reload": "Try to reload",
        },
        networkDown: {
            "head_networkDown_networkdown": "network down",
            "description_networkDown_down": "Sorry, we are down for the moment",
            "description_networkDown_contact": "Please contact the operator",
        }
    },
    cz: {
        languages: {
            "btn_selectlanguage_czech": "Česky",
            "btn_selectlanguage_english": "Anglicky",
            "btn_selectlanguage_french": "Français",
            "btn_selectlanguage_magyar": "Magyar",
            "btn_selectlanguage_deutch": "Deutch",
        },
        scanqrcode: {
            "header_scanqrcode_welcome": "Vítejte v Ekosystému AppUmbrella.",
            "header_scanqrcode_QRscan": "Pro pokračování naskenujte svůj QR kód.",
            "error_scanqrcode_error": "Chyba skenování.",
            "error_scanqrcode_again": "Prosím opakujte skenování QR kódu.",
            "error_scanqrcode_error2": "Chyba skenování.",
            "error_scanqrcode_again2": "Prosím opakujte skenování QR kódu.",
        },
        home: {
            "header_home_welcome": "Vítejte v Ekosystému AppUmbrella.",
            "header_home_qrscan": "Pro pokračování naskenujte svůj QR kód.",
            "text_home_continue": "Pokračujte dotykem",
        },
        smsvalidation: {
            "description_smsvalidation_smstodevice": "Na Vaše zařízení byl odeslán SMS kód.",
            "description_blocksms_smstodevice": "Na Vaše zařízení byl odeslán SMS kód.",
            "description_smsvalidation_enter": "Zadejte prosím",
            "description_smsvalidation_authentication": "SMS autorizační kód",
            "error_smsvalidation_red": "Chyba.",
            "error_smsvalidation_again": "Opakujte prosím",
            "error_smsvalidation_enter": "zadání SMS kódu.",
        },
        banknotes: {
            "btn_banknotes_withdrawal": "VÝBĚR",
            "btn_banknotes_deposit": "VKLAD",
            "btn_banknotes_aupay": "AUPAY",
            "description_banknotes_insert": "Bankovky vkládejte a vybírejte jednotlivě!",
        },
        confirmamount: {
            "btn_confirmamount_another": "JINÁ",
            "btn_confirmamount_sum": "Celková částka",
            "description_confirmamount_banknotes": "Bankovky se vydávají jednotlivě!",
            "btn_confirmamount_closing": "Ukončit",
        },
        print: {
            "head_print_certification": "Přejete si pro tuto transakci potvrzení?",
            "btn_print_no": "NE",
            "btn_print_yes": "ANO",
            "btn_print_closing": "Ukončit",
        },
        continue: {
            "head_continue_continue": "Dekujeme. Pokracovat?",
            "btn_continue_no": "NE",
            "btn_continue_yes": "ANO",
            "btn_continue_close": "Ukončit"
        },
        removecash: {
            "description_removecash_take": "Odeberte&nbsp;hotovost",
            "description_removecash_giveout": "Bankomat&nbsp;vydává",
            "description_removecash_banknotes": "bankovky&nbsp;jednotlivě!",
            "btn_removecash_closing": "Ukončit",
        },
        usingservice: {
            "header_usingservice_thanksforuse": "Děkujeme za využití naší služby.",
            "btn_usingservice_logout": "Odhlásit",
            "btn_usingservice_continue": "Pokračovat",
        },
        transactioncancel: { "description_transactioncancel_cancel": "Transakce&nbsp;zrušena." },
        withdrawamount: {
            "description_withdrawamount_write500": "Zadejte&nbsp;násobek&nbsp;hodnoty&nbsp;500&nbsp;Kč!",
            "error_withdrawamount_error": "Chybná částka.",
            "error_withdrawamount_again": "Opakujte zadání.",
            "btn_withdrawamount_closing": "Ukončit",
            "error_withdrawamount_toohigherr": "nedostatek hotovosti v penezence",
            "error_withdrawamount_notenougherr": "nedostatek bankovek k dispozici",
        },
        banknote: {
            "btn_banknote_withdrawal": "VÝBĚR",
            "btn_banknote_deposit": "VKLAD",
            "btn_banknote_aupay": "AUPAY",
            "description_banknote_insert": "Bankovky vkládejte a vybírejte jednotlivě!",
        },
        transferamount: {
            "header_transferamount_deposite": "Kolik chcete vložit?",
            "header_transferamount_accept": "Bankomat přijímá bankovky v nominální hodnotě",
            "header_transferamount_amount": "500 Kč, 1000 Kč a 2000 Kč.",
            "error_transferamount_wrongsum": "Chybná částka.",
            "error_transferamount_sumagain": "Opakujte zadání.",
            "btn_transferamount_closing": "Ukončit",
        },
        depositamount: {
            "header_depositamount_deposite": "Kolik chcete vložit?",
            "header_depositamount_accept": "Bankomat přijímá bankovky v nominální hodnotě",
            "header_depositamount_amount": "500 Kč, 1000 Kč a 2000 Kč.",
            "error_depositamount_wrongsum": "Chybná částka.",
            "error_depositamount_sumagain": "Opakujte zadání.",
            "btn_depositamount_closing": "Ukončit",
        },
        Insertbanknotes: {
            "header_insertbanknotes_insert": "Vložte bankovky",
            "header_insertbanknotes_accept": "Bankomat přijímá bankovky v nominální hodnotě",
            "header_insertbanknotes_amount": "500 Kč, 1000 Kč a 2000 Kč.",
            "description_insertbanknotes_putin": "Bankovky&nbsp;vkládejte",
            "description_insertbanknotes_individually": "jednotlivě",
            "label_insertbanknotes_paid": "Vloženo",
            "label_insertbanknotes_tobepaid": "Zbýva",
            "label_insertbanknotes_sum": "Celkem",
            "btn_insertbanknotes_confirm": "Potvrdit",
            "btn_insertbanknotes_closing": "Ukončit",
        },
        InsertBanknotes: {
            "header_InsertBanknotes_insert": "Vložte bankovky",
            "header_InsertBanknotes_accept": "Bankomat přijímá bankovky v nominální hodnotě",
            "header_InsertBanknotes_amount": "500 Kč, 1000 Kč a 2000 Kč.",
            "description_InsertBanknotes_putin": "Bankovky&nbsp;vkládejte",
            "description_InsertBanknotes_individually": "jednotlivě",
            "label_InsertBanknotes_paid": "Vloženo",
            "label_InsertBanknotes_tobepaid": "Zbýva",
            "label_InsertBanknotes_sum": "Celkem",
            "btn_InsertBanknotes_confirm": "Potvrdit",
            "btn_InsertBanknotes_closing": "Ukončit",
            "filed_required": "Všetky požadované údaje",
            "description_insertBanknotes_wrong": "nesprávná vložená hodnota",
        },
        InsertBanknote: {
            "header_InsertBanknote_insert": "Vložte bankovky",
            "header_InsertBanknote_accept": "Bankomat přijímá bankovky v nominální hodnotě",
            "header_InsertBanknote_amount": "500 Kč, 1000 Kč a 2000 Kč.",
            "description_InsertBanknote_putin": "Bankovky&nbsp;vkládejte",
            "description_InsertBanknote_individually": "jednotlivě",
            "label_InsertBanknote_paid": "Vloženo",
            "label_InsertBanknote_tobepaid": "Zbýva",
            "label_InsertBanknote_sum": "Celkem",
            "btn_InsertBanknote_confirm": "Potvrdit",
            "btn_InsertBanknote_closing": "Ukončit",
        },
        deposit: {
            "header_deposit_amount": "Vložená částka",
            "btn_deposite_sendviaaupay": "Vložit via AuPay",
            "btn_deposite_tomyaccount": "Vložit Sobě",
            "btn_deposite_closing": "Ukončit",
        },
        DepositeQR: {
            "header_DepositeQR_viaaupay": "Vklad via AuPay",
            "header_DepositeQR_scan": "Naskenujte QR kód příjemce",
            "error_DepositeQR_error": "Chyba skenování.",
            "error_DepositeQR_qragain": "Prosím opakujte skenování QR kódu.",
            "btn_DepositeQR_closing": "Ukončit",
        },
        confirmrecipitent: {
            "header_confirmrecipitent_amountdeposited": "Vložená částka",
            "description_confirmrecipitent_recipient": "Příjemce: Don Ready",
            "btn_confirmrecipitent_confirm": "Potvrdit",
            "btn_confirmrecipitent_closing": "Ukončit",
        },
        connectethernet: {
            "header_connectethernet_networkdown": "síť dolů",
            "description_connectethernet_verify": "Připojte prosím ethernetový kabel nebo ověřte jeho připojení.",
        },
        bootingup: {
            "header_bootingup_bootingup": "Zavádění systému...",
            "description_bootingup_initialhardware": "Inicializace hardwaru.",
            "description_bootingup_moment": "Za chvíli budeme nahoře.",
        },
        initializing: {
            "header_initializing_initializing": "Inicializace...",
            "description_initializing_cryptographicidentity": "Generování kryptografické identity.",
            "description_initializing_wait": "Počkejte prosím několik minut.",
        },
        connecting: {
            "head_connecting_connecting": "Spojovací...",
        },
        pairing: {
            "head_pairing_pairing": "Párování...",
        },
        pairingerror: {
            "head_pairing_pairingfailed": "Párování selhalo",
            "description_pairing_error": "Při pokusu o párování došlo k chybě:",
            "btn_pairing_again": "Zkus to znovu",
        },
        pairingscan: {
            "head_pairingscan_pair": "Spárujte se vzdáleným serverem",
            "description_pairingscan_scanqr": "Zkontrolujte prosím párovací QR kód, který jste dostali ze vzdáleného serveru.",
            "btn_pairingscan_cancel": "zrušení",
        },
        virgin: {
            "head_virgin_congratulations": "Gratulujeme!",
            "description_virgin_welcome": "Vítejte ve vašem novém Bankomatu.",
            "description_virgin_initialize": "Stisknutím inicializace vygenerujete pro svůj počítač zabezpečený kryptografický certifikát. To by mohlo trvat asi patnáct minut.",
            "btn_virgin_initialize": "Inicializovat",
            "description_virgin_generatecertificate": "Inicializovat",
        },
        maintenance: {
            "head_maintenance_required": "Vyžaduje se údržba",
            "description_maintenance_contactoperator": "Obraťte se prosím na provozovatele.",
        },
        depositenetworkdown: {
            "head_depositenetworkdown_networkdown": "Síť dolů",
            "description_depositenetworkdown_downmoment": "Promiňte, momentálně jsme dole.",
            "description_depositenetworkdown_comback": "Vraťte se prosím později.",
            "btn_depositenetworkdown_ok": "OK",
        },
        wificonnecting: {
            "head_wificonnecting_connecting": "Spojovací...",
        },
        unpaired: {
            "head_unpaired_pair": "Spárujte se vzdáleným serverem",
            "description_unpaired_scanqr": "Stiskněte tlačítko SKENOVÁNÍ a přednastavte zařízení párovacím QR kódem ze vzdáleného serveru.",
            "description_unpaired_important": "DŮLEŽITÉ: Udržujte zařízení v bezpečí, dokud se úspěšně nespárujete se vzdáleným serverem.",
        },
        disconnect: {
            "head_disconnect_fail": "Nepodařilo se připojit k počítači",
            "text_disconnect_reload": "Zkuste znovu načíst",
        },
        networkDown: {
            "head_networkDown_networkdown": "síť dolů",
            "description_networkDown_down": "Promiňte, momentálně jsme dole",
            "description_networkDown_contact": "Obraťte se prosím na provozovatele",
        }
    }
};

var CONSTANTS = {
    CssHelpers: {
        NoDisplay: "nodisplay",
        ViewPort: "viewport",
        CurrentPage: "currentPage"
    }
};

var ATM = {
    defaultLanguage: "en",
    defaultPage: "logo",
    debugMode: true,
    fixedSize: false,
    pages: {},
    currentPage: "",
    qrreader: true,
    printing_status: true,
    smscode_status: true,
    transaction_cancel: false,
    machinePort: 9001,
    machineHost: "localhost",
    confirmBeep: null,
    accepting: false,
    websocket: null,
    verifyConnectionInterval: 1000,
    count: 0,
    autoLogout: {
        idleTimeout: 10000,
        checkIdle: true,
        checkActivity: function checkActivity() {

            if (ATM.autoLogout.checkIdle === true) {
                var t;
                window.onload = () => {
                    t = ATM.autoLogout.resetTimeout(t);
                };
                window.onmousemove = () => {
                    t = ATM.autoLogout.resetTimeout(t);
                };
                window.onmousedown = () => {
                    t = ATM.autoLogout.resetTimeout(t);
                };
                window.ontouchstart = () => {
                    t = ATM.autoLogout.resetTimeout(t);
                };
                window.onclick = () => {
                    t = ATM.autoLogout.resetTimeout(t);
                };
                window.onkeypress = () => {
                    t = ATM.autoLogout.resetTimeout(t);
                };
                window.addEventListener("scroll", () => {
                    t = ATM.autoLogout.resetTimeout(t);
                }, true);
            }
        },
        handleNoActivity: function handleNoActivity() {
            ATM.logout();
        },
        resetTimeout: function resetTimeout(t) {
            clearTimeout(t);
            t = setTimeout(ATM.autoLogout.handleNoActivity, ATM.autoLogout.idleTimeout);

            return t;
        }
    },
    showPage: function showPage(name) {

        if (name === ATM.currentPage) return;

        ATM.log("showPage: " + name);

        var page = document.querySelector(name);

        if (ATM.currentPage !== name) {

            var pageSelected = document.querySelector("." + CONSTANTS.CssHelpers.CurrentPage);

            page.classList.remove(CONSTANTS.CssHelpers.ViewPort);
            if (pageSelected) {
                pageSelected.classList.add(CONSTANTS.CssHelpers.ViewPort);
                pageSelected.classList.remove(CONSTANTS.CssHelpers.CurrentPage);
            }
            page.classList.remove(CONSTANTS.CssHelpers.CurrentPage);
            page.classList.add(CONSTANTS.CssHelpers.CurrentPage);
        }

        ATM.currentPage = name;

        var messages = page.querySelectorAll(".ImBlockMessage");

        for (i = 0; i < messages.length; i++) {
            messages[i].classList.add(CONSTANTS.CssHelpers.NoDisplay);
        }

    },
    showBlock: function showBlock(name) {

        ATM.log("showBlock: " + name);

        var obj = document.querySelector(name);
        var parentObj = obj.parentNode;
        var childHidObj;
        obj.classList.remove(CONSTANTS.CssHelpers.NoDisplay);
        if (obj != null) {

            try {
                for (var i = 1; i < parentObj.childNodes.length; i++) {

                    if (parentObj.childNodes[i].classList.contains('block') == true) {
                        childHidObj = parentObj.childNodes[i];
                        break;
                    }
                }
            }
            catch (error) {
                try {
                    for (var i = i + 1; i < parentObj.childNodes.length; i++) {

                        if (parentObj.childNodes[i].classList.contains('block') == true) {
                            childHidObj = parentObj.childNodes[i];
                            break;
                        }
                    }
                }
                catch (error) {
                    ATM.log(error);
                }
            }

            if (childHidObj) {
                childHidObj.classList.add(CONSTANTS.CssHelpers.NoDisplay);
            }
        }
    },
    hideBlock: function hideBlock(name) {
        ATM.log("hideBlock: " + name);
        var obj = document.querySelector(name);

        if (obj != null) {
            obj.classList.add(CONSTANTS.CssHelpers.NoDisplay);
        }
    },
    clearForm: function clearForm(name) {

    },
    switchDebugMode: function switchDebugMode() {

        if (ATM.debugMode === false)
            ATM.debugMode = true;
        else
            ATM.debugMode = false;

        var debugHelpers = document.getElementById('debug-helpers');
        var obj = document.querySelector('.debug-pages');

        if (ATM.debugMode === true) {

            var i;
            var stringBuilder = "<ul>";

            debugHelpers.classList.remove(CONSTANTS.CssHelpers.ViewPort);

            var sections = document.querySelectorAll('section.ImPage');

            for (i = 0; i < sections.length; i++) {

                stringBuilder += '<li><a href="javascript:ATM.showPage(\'#' + sections[i].id + '\')">' + sections[i].id + '</a></li>';

                var errors = sections[i].querySelectorAll('.ImBlockMessage');

                var msgList = "<ul>";

                for (var e = 0; e < errors.length; e++) {
                    for (var ec = 0; ec < errors[e].classList.length; ec++) {
                        if (errors[e].classList[ec].toString().includes('block_')) {
                            msgList += '<li><a href="javascript:ATM.showBlock(\'#' + sections[i].id + ' .' + errors[e].classList[ec] + '\')">' + errors[e].classList[ec] + '</a></li>';
                        }
                    }
                }

                msgList += "</ul>";
                stringBuilder += msgList;

            }

            stringBuilder += "</ul>";

            obj.innerHTML = stringBuilder;
        }
        else {
            debugHelpers.classList.add(CONSTANTS.CssHelpers.ViewPort);
            obj.innerHTML = "";
        }

        ATM.log("switchDebugMode: " + ATM.debugMode);
    },
    switchFixedSize: function switchFixedSize() {
        if (ATM.fixedSize === false)
            ATM.fixedSize = true;
        else
            ATM.fixedSize = false;

        ATM.log("switchFixedSize: " + ATM.fixedSize);

        if (ATM.fixedSize)
            document.body.classList.add("FixedSize");
        else
            document.body.classList.remove("FixedSize");
    },
    setLanguage: function setLanguage(name) {

        ATM.log("setLanguage: " + name);

        var currentLanguage = Translations[name];

        for (var pageName in currentLanguage) {
            for (var translationKey in currentLanguage[pageName]) {
                var obj = document.querySelector(ATM.pages[pageName].classSelector + " ." + translationKey);
                if (obj != null) {
                    obj.innerHTML = currentLanguage[pageName][translationKey];
                }
                else {
                    ATM.log("translation ERROR: " + pageName + ":" + translationKey);
                }
            }
        }
    },
    logout: function logout() {

        //we dont need to do logout if we are not logged in
        if (ATM.currentPage !== ATM.pages[ATM.defaultPage].classSelector) {

            ATM.log("logout:" + ATM.currentPage);
            location.href = location.href;
        }
    },
    log: function log(data) {

        if (typeof console !== 'undefined' && ATM.debugMode === true) {
            console.info(data);
        }
    },
    print: function print() {

        ATM.log("print:");
        return true;
    },
    processData: function processData(data) {

        ATM.log("processData:" + data.action);
        if (ATM.count > 0) {
            return;
        }
        switch (data.action) {
            case 'wifiList':
                ATM.showPage(ATM.pages["connectethernet"].classSelector);
                break;
            case 'connecting':
                ATM.showPage(ATM.pages["connecting"].classSelector);
                break;
            case 'wifiConnecting':
                ATM.showPage(ATM.pages["wificonnecting"].classSelector);
                break;
            case 'wifiConnected':
                ATM.showPage(ATM.pages["wificonnecting"].classSelector);
                break;
            case 'pairing':
                ATM.showPage(ATM.pages["pairing"].classSelector);
                break;
            case 'virgin':
                ATM.showPage(ATM.pages["virgin"].classSelector);
                break;
            case 'pairingError':
                setTimeout(function () { ATM.showPage(ATM.pages["pairingerror"].classSelector); }, 500);
                break;
            case 'booting':
                if (ATM.currentPage !== 'maintenance') ATM.showPage(ATM.pages["bootingup"].classSelector);
                break;
            case 'restart':
                ATM.showPage(ATM.pages["restart"].classSelector);
                break;
            case 'networkDown':
                ATM.showPage(ATM.pages["networkDown"].classSelector);
                ATM.autoLogout.checkActivity();
                break;
            case 'chooseCoin':
                ATM.showPage(ATM.pages[ATM.defaultPage].classSelector);
                ATM.count++;
                ATM.autoLogout.checkActivity();
                break;
            default:
                //alert(data.action)
                if (data.action) ATM.showPage(ATM.pages[data.action].classSelector);
                break;
        }
    },
    sendData(button, data) {
        var res = { button: button };
        if (data || data === null) res.data = data;
        ATM.websocket.send(JSON.stringify(res));
    },
    connect: function connect() {

        ATM.log(`ws://${ATM.machineHost}:${ATM.machinePort}/`);

        setInterval(ATM.verifyConnection, ATM.verifyConnectionInterval);

        ATM.websocket = new WebSocket(`ws://${ATM.machineHost}:${ATM.machinePort}/`);

        ATM.log(ATM.websocket);

        ATM.websocket.onmessage = function (event) {
            var data = JSON.parse(event.data);
            ATM.processData(data);
        };

        ATM.websocket.onerror = err => ATM.log(err);
    },
    verifyConnection: function verifyConnection() {

        if (ATM.websocket.readyState === ATM.websocket.CLOSED) {
            ATM.connect();
            ATM.showPage(ATM.pages["disconnect"].classSelector);
        }
    },
    init: function init() {

        var mode = new URLSearchParams(window.location.search).get("mode");

        if (mode !== null && mode === "debug") {
            ATM.switchDebugMode();
        }

        var pages = document.querySelectorAll('.ImPage');

        for (var p = 0; p < pages.length; p++) {

            var pageName = pages[p].id.replace('-page', '').replace('system-', '');

            //var translations = document.getElementById(pages[p].id).getElementsByClassName('ImTranslated');
            var pageObjects = [];
            ATM.pages[pageName] = { classSelector: "#" + pages[p].id, pageObjects: pageObjects };
        }

        ATM.setLanguage(ATM.defaultLanguage);

        ATM.connect();
    }
};

ATM.init();