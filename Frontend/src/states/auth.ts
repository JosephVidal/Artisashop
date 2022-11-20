import { useAtom } from 'jotai';
import { RESET } from 'jotai/utils';
import { AccountApi, AccountToken, AccountViewModel, Configuration, Register } from 'api';
import { REACT_APP_API_URL } from 'conf';
import useratom from './atoms/user';
import tokenatom from './atoms/token';

export interface IProvideAuth {
  user?: AccountViewModel | null
  signin: (username: string, password: string) => Promise<AccountToken>
  signup: (model: Register) => Promise<AccountToken>
  signout: () => void
  confirmPasswordReset: (code: string, password: string) => void
  sendPasswordResetEmail: (email: string) => void
  token?: string | null
}

const useAuth: () => IProvideAuth = () => {
  const [user, setUser] = useAtom(useratom);
  const [token, setToken] = useAtom(tokenatom);

  const api = new AccountApi(new Configuration({
    basePath: REACT_APP_API_URL,
  }));

  const signin = (email: string, password: string) => api.apiAccountLoginPost({
      login: {email, password},
    }).then(res => {
      setUser(res.user ?? null)
      setToken(res.token ?? null)
      return res
    });

  const signup = (register: Register) => api.apiAccountPost({
      register
    }).then(res => {
      setUser(res.user ?? null)
      setToken(res.token ?? null)
      return res
    });

  const signout = () => {
    setUser(RESET);
    setToken(RESET);
  };

  const sendPasswordResetEmail = (email: string) => {
    // TODO: implement
  };

  const confirmPasswordReset = (code: string, password: string) => {
    // TODO: implement
  };

  return {
    user,
    token,
    signin,
    signup,
    signout,
    sendPasswordResetEmail,
    confirmPasswordReset,
  };
};

export default useAuth;
