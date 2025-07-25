namespace BetterAuth.Constants;

public sealed class BaseErrorCodes
{
    public const string USER_NOT_FOUND = "User not found";
	public const string FAILED_TO_CREATE_USER = "Failed to create user";
	public const string FAILED_TO_CREATE_SESSION = "Failed to create session";
	public const string FAILED_TO_UPDATE_USER = "Failed to update user";
	public const string FAILED_TO_GET_SESSION = "Failed to get session";
	public const string INVALID_PASSWORD = "Invalid password";
	public const string INVALID_EMAIL = "Invalid email";
	public const string INVALID_EMAIL_OR_PASSWORD = "Invalid email or password";
	public const string SOCIAL_ACCOUNT_ALREADY_LINKED = "Social account already linked";
	public const string PROVIDER_NOT_FOUND = "Provider not found";
	public const string INVALID_TOKEN = "invalid token";
	public const string ID_TOKEN_NOT_SUPPORTED = "id_token not supported";
	public const string FAILED_TO_GET_USER_INFO = "Failed to get user info";
	public const string USER_EMAIL_NOT_FOUND = "User email not found";
	public const string EMAIL_NOT_VERIFIED = "Email not verified";
	public const string PASSWORD_TOO_SHORT = "Password too short";
	public const string PASSWORD_TOO_LONG = "Password too long";
	public const string USER_ALREADY_EXISTS = "User already exists";
	public const string EMAIL_CAN_NOT_BE_UPDATED = "Email can not be updated";
	public const string CREDENTIAL_ACCOUNT_NOT_FOUND = "Credential account not found";
	public const string SESSION_EXPIRED = "Session expired. Re-authenticate to perform this action.";
	public const string FAILED_TO_UNLINK_LAST_ACCOUNT = "You can't unlink your last account";
	public const string ACCOUNT_NOT_FOUND = "Account not found";
	public const string USER_ALREADY_HAS_PASSWORD = "User already has a password. Provide that to delete the account.";
}
