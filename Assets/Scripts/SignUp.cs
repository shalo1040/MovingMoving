/*
 * 사용자 회원가입 구현 스크립트
 */ 
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SignUp : MonoBehaviour
{
    GameObject signUpView, errorView, signInView;
    InputField passwordInput, passwordInput2;
    Text newUserName, newPassword, errorMsg, userName, password;
    Button submitBtn, closeBtn, toSignInBtn, signInBtn;

    bool isOK = false;
    bool runOnce = true;

    void Start()
    {
        signUpView = GameObject.Find("SignUpBackground");
        errorView = GameObject.Find("ErrorMsgView");
        signInView = GameObject.Find("SignInBackground");

        passwordInput = GameObject.Find("SignUpBackground/PasswordInput").GetComponent<InputField>();
        passwordInput2 = GameObject.Find("SignInBackground/PasswordInput").GetComponent<InputField>();

        newUserName = GameObject.Find("SignUpBackground/NameInput/Text").GetComponent<Text>();
        newPassword = GameObject.Find("SignUpBackground/PasswordInput/Text").GetComponent<Text>();
        errorMsg = GameObject.Find("ErrorMsgView/ErrorMsg").GetComponent<Text>();
        userName = GameObject.Find("SignInBackground/NameInput/Text").GetComponent<Text>();
        password = GameObject.Find("SignInBackground/PasswordInput/Text").GetComponent<Text>();

        submitBtn = GameObject.Find("SignUpBackground/CloseBtn").GetComponent<Button>();
        closeBtn = GameObject.Find("ErrorMsgView/Button").GetComponent<Button>();
        toSignInBtn = GameObject.Find("SignUpBackground/askLoginImg/loginBtn").GetComponent<Button>();
        signInBtn = GameObject.Find("SignInBackground/CloseBtn").GetComponent<Button>();

        errorView.SetActive(false);
        signInView.SetActive(false);


        submitBtn.onClick.AddListener(Submit);
        closeBtn.onClick.AddListener(Close);
        toSignInBtn.onClick.AddListener(ToSignIn);
        signInBtn.onClick.AddListener(SignIn);
    }

    private void Update()
    {

    }

    void SignIn()
    {
        isOK = true;

        if (userName.text == "")
        {
            errorMsg.text = "닉네임을 입력하세요.";
            errorView.SetActive(true);
            isOK = false;
        }
        else if (userName.text.Length > 10)
        {
            errorMsg.text = "닉네임은 10자 이내로 입력하세요.";
            errorView.SetActive(true);
            isOK = false;
        }
        else if (password.text == "")
        {
            errorMsg.text = "비밀번호를 입력하세요.";
            errorView.SetActive(true);
            isOK = false;
        }
        else if (password.text.Length < 6)
        {
            errorMsg.text = "비밀번호는 6자 이상으로 입력하세요.";
            errorView.SetActive(true);
            isOK = false;
        }

        if (isOK) StartCoroutine(LogIn());
    }
    void Submit()
    {
        isOK = true;
        
        if (newUserName.text == "") {
            errorMsg.text = "닉네임을 입력하세요.";
            errorView.SetActive(true);
            isOK = false;
        } else if (newUserName.text.Length > 10) {
            errorMsg.text = "닉네임은 10자 이내로 입력하세요.";
            errorView.SetActive(true);
            isOK = false;
        } else if (newPassword.text == "") {
            errorMsg.text = "비밀번호를 입력하세요.";
            errorView.SetActive(true);
            isOK = false;
        } else if (newPassword.text.Length < 6) {
            errorMsg.text = "비밀번호는 6자 이상으로 입력하세요.";
            errorView.SetActive(true);
            isOK = false;
        }
            
        if(isOK) StartCoroutine(CheckID());
    }

    IEnumerator LogIn()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userName", userName.text);
        wwwForm.AddField("password", passwordInput2.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodol/users_login.php", wwwForm))
        {

            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            string t = www.downloadHandler.text;
            Debug.Log(t);
            if(t=="invalid")
            {
                errorMsg.text = "아이디와 비밀번호를 확인해주세요.";
                errorView.SetActive(true);
            } else
            {
                Singleton.Instance.userID = int.Parse(t.ToString());
                Debug.Log(Singleton.Instance.userID);
                SceneManager.LoadScene("Scene00_Main");
            }
        }
    }
    //닉네임 중복확인
    IEnumerator CheckID()
    {
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userName", newUserName.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodol/users_checkId.php", wwwForm))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            string t = www.downloadHandler.text;
            Debug.Log("check "+t);
            int num = int.Parse(t.ToString());
            if(num!=0)
            {
                errorMsg.text = "이미 존재하는 닉네임입니다.";
                errorView.SetActive(true);
            } else if (runOnce) StartCoroutine(InsertUser());
        }
    }

    //회원가입
    IEnumerator InsertUser()
    {
        runOnce = false;

        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("userName", newUserName.text);
        wwwForm.AddField("password", passwordInput.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://condi.swu.ac.kr/student/Dodol/users_insert.php", wwwForm))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            string t = www.downloadHandler.text;
            Debug.Log(t);
            Singleton.Instance.userID = int.Parse(t.ToString());
            Debug.Log("userID: " + Singleton.Instance.userID);
            SceneManager.LoadScene("Scene00_Main");
        }
    }

    void Close()
    {
        errorView.SetActive(false);
    }

    void ToSignIn()
    {
        signUpView.SetActive(false);
        errorView.SetActive(false);
        signInView.SetActive(true);
    }
}
