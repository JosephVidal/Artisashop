/* eslint-disable no-param-reassign */
import { fetchUtils } from 'react-admin';
import tokenAtom from 'states/atoms/token';
import { useAtom } from 'jotai';

const fetchJson = (url : string, options: fetchUtils.Options = {}) => {
  const [token] = useAtom(tokenAtom);

  options.user = {
    authenticated: true,
    // use the token from local storage
  };
  options.headers = new Headers({ 
    Accept: 'application/json',
    Authorization: `Bearer ${token ?? ''}`,
  });
  return fetchUtils.fetchJson(url, options);
}; 

export default fetchJson;
