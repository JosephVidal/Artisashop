import {
    Flex,
    Box,
    FormControl,
    FormLabel,
    Input,
    Checkbox,
    Stack,
    Link,
    Button,
    Heading,
    Text,
    useColorModeValue,
} from '@chakra-ui/react';
import {Link as RouterLink, useNavigate} from "react-router-dom";
import useApiUrl from "../../hooks/useApiUrl";
import {useFormik} from "formik";
import {useAuth} from "../../hooks/useAuth";

export default function SimpleCard() {
    const auth = useAuth()
    const navigate = useNavigate()
    const formik = useFormik({
        initialValues: {
            email: "",
            password: "",
        },
        onSubmit: (values => {
                auth?.signin(values.email, values.password)
                    .then(res => res.user && navigate("/"))
            }
        )
    })
    return (
        <Flex
            minH={'100vh'}
            align={'center'}
            justify={'center'}
            bg={useColorModeValue('gray.50', 'gray.800')}>
            <form onSubmit={formik.handleSubmit}>
                <Stack spacing={8} mx={'auto'} maxW={'lg'} py={12} px={6}>
                    <Stack align={'center'}>
                        <Heading fontSize={'4xl'}>Sign in to your account</Heading>
                        <Text fontSize={'lg'} color={'gray.600'}>
                            to enjoy all of our cool <Link color={'blue.400'}>features</Link> ✌️
                        </Text>
                    </Stack>
                    <Box
                        rounded={'lg'}
                        bg={useColorModeValue('white', 'gray.700')}
                        boxShadow={'lg'}
                        p={8}>
                        <Stack spacing={4}>
                            <FormControl id="email">
                                <FormLabel>Email</FormLabel>
                                <Input
                                    name="email"
                                    type="text"
                                    value={formik.values.email}
                                    onChange={formik.handleChange}
                                />
                            </FormControl>
                            <FormControl id="password">
                                <FormLabel>Password</FormLabel>
                                <Input
                                    name="password"
                                    type="password"
                                    value={formik.values.password}
                                    onChange={formik.handleChange}
                                />
                            </FormControl>
                            <Stack spacing={10}>
                                <Stack
                                    direction={{base: 'column', sm: 'row'}}
                                    align={'start'}
                                    justify={'space-between'}>
                                    <Checkbox>Remember me</Checkbox>
                                    <Link color={'blue.400'}>Forgot password?</Link>
                                </Stack>
                                <Button
                                    type="submit"
                                    bg={'blue.400'}
                                    color={'white'}
                                    _hover={{
                                        bg: 'blue.500',
                                    }}>
                                    Sign in
                                </Button>
                            </Stack>
                            <Stack pt={6}>
                                <Text align={'center'}>
                                    No account yet?&nbsp;
                                    <Link as={RouterLink} to="/auth/register" color={'blue.400'}>
                                        Register
                                    </Link>
                                </Text>
                            </Stack>
                        </Stack>
                    </Box>
                </Stack>
            </form>
        </Flex>
    );
}
