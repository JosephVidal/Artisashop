import { AccountViewModel } from 'api';
import { atomWithStorage } from 'jotai/utils';

const userAtom = atomWithStorage<AccountViewModel | null>('user', null);

export default userAtom;
