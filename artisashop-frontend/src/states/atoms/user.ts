import { atomWithStorage } from 'jotai/utils';

import { AccountViewModel } from '../../api';

const userAtom = atomWithStorage<AccountViewModel | null>('user', null);

export default userAtom;
