import {ReactNode} from "react";
import {
    Avatar,
    Box,
    Button, Center,
    Flex,
    HStack,
    Menu, MenuButton, MenuDivider, MenuItem, MenuList,
    Stack,
    Text,
    useColorMode,
    useColorModeValue,
    useDisclosure
} from "@chakra-ui/react";
import {useAuth} from "../../hooks/useAuth";
import {NavLink, Link, useNavigate} from "react-router-dom";
import {ChatIcon, MoonIcon, SunIcon} from "@chakra-ui/icons";

const Nav = () => {
    const {colorMode, toggleColorMode} = useColorMode();
    // const navigate = useNavigate();
    const auth = useAuth();
    
    const handleLogoff = () => {
        auth?.signout();
        // navigate('/');
    };

    return (
        <>
            <Box bg={useColorModeValue('gray.100', 'gray.900')} px={4}>
                <Flex h={16} alignItems={'center'} justifyContent={'space-between'}>
                    <HStack spacing={3}>
                        <Text fontWeight="bold" fontSize="2xl" as={NavLink} to="/">
                            Artisashop
                        </Text>
                        <Button as={NavLink} to="/artisans">Rechercher Artisan</Button>
                        <Menu>
                            <MenuButton>A propos</MenuButton>
                            <MenuList>
                                <MenuItem as={NavLink} to="/a-propos/politique-confidentialite">Politique de
                                    confidentialité</MenuItem>
                            </MenuList>
                        </Menu>
                    </HStack>

                    <Flex alignItems={'center'}>
                        <Stack direction={'row'} spacing={7}>
                            <HStack spacing={3}>
                                <Button onClick={toggleColorMode}>
                                    {colorMode === 'light' ? <MoonIcon/> : <SunIcon/>}
                                </Button>

                                <Button as={NavLink} to="/chat/dumbledore" variant="ghost">
                                    <ChatIcon/>
                                </Button>
                            </HStack>

                            {auth?.user === null
                                ? <HStack>
                                    <Button as={NavLink} to="/auth/login">Login</Button>
                                    <Button as={NavLink} to="/auth/register">Register</Button>
                                </HStack>
                                : <Menu>
                                    <MenuButton
                                        as={Button}
                                        rounded={'full'}
                                        variant={'link'}
                                        cursor={'pointer'}
                                        minW={0}>
                                        <Avatar
                                            size={'sm'}
                                            src={`https://avatars.dicebear.com/api/male/${auth?.user?.username}.svg`}
                                        />
                                    </MenuButton>
                                    <MenuList alignItems={'center'}>
                                        <br/>
                                        <Center>
                                            <Avatar
                                                size={'2xl'}
                                                src={`https://avatars.dicebear.com/api/male/${auth?.user?.username}.svg`}
                                            />
                                        </Center>
                                        <br/>
                                        <Center>
                                            <p>{auth?.user?.username ?? "???"}</p>
                                        </Center>
                                        <br/>
                                        <MenuDivider/>
                                        <MenuItem as={Link} to="/profile">Votre profil</MenuItem>
                                        <MenuItem onClick={handleLogoff}>Logout</MenuItem>
                                    </MenuList>
                                </Menu>
                            }
                        </Stack>
                    </Flex>
                </Flex>
            </Box>
        </>
    );
}

export default Nav;