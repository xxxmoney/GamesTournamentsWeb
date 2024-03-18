import axios from 'axios'

const useApi = () => {
  // TODO: fix baseURL
  const baseURL = process.env.API || 'http://localhost:5162/api'

  const mainStore = useMainStore()

  return axios.create({
    baseURL,
    headers: {
      Authorization: `Bearer ${mainStore.loginResult?.token ?? ''}`
    }
  })
}

export { useApi }
