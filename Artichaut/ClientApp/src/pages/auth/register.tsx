import {
    Flex,
    Box,
    FormControl,
    FormLabel,
    Input,
    InputGroup,
    InputRightElement,
    Stack,
    Button,
    Heading,
    Text,
    useColorModeValue,
    Link,
} from '@chakra-ui/react';
import {Link as RouterLink, useNavigate} from "react-router-dom";
import {useFormik} from "formik";
import {useState} from 'react';
import {ViewIcon, ViewOffIcon} from '@chakra-ui/icons';

import {useAuth} from "../../hooks/useAuth";
import { UserType } from '../../api';

export default function SignupCard() {
    const [showPassword, setShowPassword] = useState(false);
    const auth = useAuth()
    const navigate = useNavigate()

    const formik = useFormik({
        initialValues: {
                firstname: '',
                lastname: '',
                email: '',
                password: '',
                role: UserType.NUMBER_0
            },
            onSubmit: (values) => {
                console.log("Connecting...")
                auth?.signup(values)
                    .then(res => res.user && navigate("/"))
            },
        }
    )

    return (
        <Flex
            minH={'100vh'}
            align={'center'}
            justify={'center'}
            bg={useColorModeValue('gray.50', 'gray.800')}>
            <Stack spacing={8} mx={'auto'} maxW={'lg'} py={12} px={6}>
                <Stack align={'center'}>
                    <Heading fontSize={'4xl'} textAlign={'center'}>
                        Sign up
                    </Heading>
                    <Text fontSize={'lg'} color={'gray.600'}>
                        to enjoy all of our cool features ✌️
                    </Text>
                </Stack>
                <form
                    onSubmit={formik.handleSubmit}
                >
                    <Box
                        rounded={'lg'}
                        bg={useColorModeValue('white', 'gray.700')}
                        boxShadow={'lg'}
                        p={8}>
                        <Stack spacing={4}>
                            <FormControl id="firstname" isRequired>
                                <FormLabel>Firstname</FormLabel>
                                <Input
                                    name="firstname"
                                    type="text"
                                    value={formik.values.firstname}
                                    onChange={formik.handleChange} />
                            </FormControl>
                            <FormControl id="lastname" isRequired>
                                <FormLabel>Lastname</FormLabel>
                                <Input
                                    name="lastname"
                                    type="text"
                                    value={formik.values.lastname}
                                    onChange={formik.handleChange} />
                            </FormControl>
                            <FormControl id="email" isRequired>
                                <FormLabel>Email address</FormLabel>
                                <Input
                                    name="email"
                                    type="text"
                                    value={formik.values.email}
                                    onChange={formik.handleChange}/>
                            </FormControl>
                            <FormControl id="password" isRequired>
                                <FormLabel>Password</FormLabel>
                                <InputGroup>
                                    <Input
                                        name="password"
                                        type={showPassword ? 'text' : 'password'}
                                        value={formik.values.password}
                                        onChange={formik.handleChange}/>
                                    <InputRightElement h={'full'}>
                                        <Button
                                            variant={'ghost'}
                                            onClick={() =>
                                                setShowPassword((showPassword) => !showPassword)
                                            }>
                                            {showPassword ? <ViewIcon/> : <ViewOffIcon/>}
                                        </Button>
                                    </InputRightElement>
                                </InputGroup>
                            </FormControl>
                            <Stack spacing={10} pt={2}>
                                <Button
                                    type="submit"
                                    loadingText="Submitting"
                                    size="lg"
                                    bg={'blue.400'}
                                    color={'white'}
                                    _hover={{
                                        bg: 'blue.500',
                                    }}
                                    disabled={formik.isSubmitting}
                                >
                                    Sign up
                                </Button>
                            </Stack>
                            <Stack pt={6}>
                                <Text align={'center'}>
                                    Already a user?&nbsp;
                                    <Link as={RouterLink} to="/auth/login" color={'blue.400'}>
                                        Login
                                    </Link>
                                </Text>
                            </Stack>
                        </Stack>
                    </Box>
                </form>
            </Stack>
        </Flex>
    );
}
